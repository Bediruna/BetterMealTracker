using System.Globalization;
using System.Text.RegularExpressions;
using CsvHelper;
using Npgsql;

var directoryPath = @"C:\Users\bedir\Downloads\FoodData";
string connString = Environment.GetEnvironmentVariable("PG_TEST_CONN_STRING")
                    ?? throw new InvalidOperationException("PG_TEST_CONN_STRING not set");

using var conn = new NpgsqlConnection(connString);
await conn.OpenAsync();

var csvFiles = Directory.GetFiles(directoryPath, "*.csv");

foreach (var filePath in csvFiles)
{
    var tableName = Path.GetFileNameWithoutExtension(filePath).ToLowerInvariant();

    // Read headers first
    string[] headers;
    using (var headerReader = new StreamReader(filePath))
    using (var csv = new CsvReader(headerReader, CultureInfo.InvariantCulture))
    {
        await csv.ReadAsync();
        csv.ReadHeader();
        headers = csv.HeaderRecord!;
    }

    var sanitizedHeaders = headers.Select(Sanitize).ToArray();

    // Create table if it doesn't exist, all TEXT columns
    var columnDefs = string.Join(", ", sanitizedHeaders.Select(h => $"\"{h}\" TEXT"));
    var createTableSql = $"CREATE TABLE IF NOT EXISTS \"{tableName}\" ({columnDefs});";
    using (var createCmd = new NpgsqlCommand(createTableSql, conn))
    {
        await createCmd.ExecuteNonQueryAsync();
    }

    // Re-read the CSV for data import
    using var dataReader = new StreamReader(filePath);
    using var csvReader = new CsvReader(dataReader, CultureInfo.InvariantCulture);
    await csvReader.ReadAsync();
    csvReader.ReadHeader();

    using var writer = conn.BeginBinaryImport(
        $"COPY \"{tableName}\" ({string.Join(", ", sanitizedHeaders.Select(h => $"\"{h}\""))}) FROM STDIN (FORMAT BINARY)"
    );

    while (await csvReader.ReadAsync())
    {
        writer.StartRow();
        foreach (var h in headers)
        {
            var val = csvReader.GetField(h);
            writer.Write(string.IsNullOrWhiteSpace(val) ? null : val, NpgsqlTypes.NpgsqlDbType.Text);
        }
    }

    await writer.CompleteAsync();
    Console.WriteLine($"Inserted rows into {tableName}");
}

string Sanitize(string input)
{
    return Regex.Replace(input, "[^a-zA-Z0-9_]", "_");
}
