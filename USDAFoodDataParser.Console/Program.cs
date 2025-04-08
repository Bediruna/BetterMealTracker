using System.Globalization;
using System.Text.RegularExpressions;
using CsvHelper;
using Dapper;
using Npgsql;

var directoryPath = @"C:\Users\bedir\Downloads\FoodData";
string connString = Environment.GetEnvironmentVariable("PG_TEST_CONN_STRING") ?? throw new InvalidOperationException("PG_TEST_CONN_STRING not set");

using var conn = new NpgsqlConnection(connString);
conn.Open();

var csvFiles = Directory.GetFiles(directoryPath, "*.csv");

foreach (var filePath in csvFiles)
{
    var tableName = Path.GetFileNameWithoutExtension(filePath).ToLowerInvariant();

    using var reader = new StreamReader(filePath);
    using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);

    csv.Read();
    csv.ReadHeader();
    var headers = csv.HeaderRecord!;

    // Create table if it doesn't exist, all TEXT columns
    var columnDefs = string.Join(", ", headers.Select(h => $"\"{Sanitize(h)}\" TEXT"));
    var createTableSql = $"CREATE TABLE IF NOT EXISTS \"{tableName}\" ({columnDefs});";
    await conn.ExecuteAsync(createTableSql);

    var records = csv.GetRecords<dynamic>().ToList();

    foreach (var record in records)
    {
        var dict = (IDictionary<string, object>)record;

        var columnList = string.Join(", ", dict.Keys.Select(k => $"\"{Sanitize(k)}\""));
        var paramList = string.Join(", ", dict.Keys.Select(k => "@" + k));
        var sql = $"INSERT INTO \"{tableName}\" ({columnList}) VALUES ({paramList})";

        await conn.ExecuteAsync(sql, new DynamicParameters(dict));
    }

    Console.WriteLine($"Inserted {records.Count} rows into {tableName}");
}

string Sanitize(string input)
{
    return Regex.Replace(input, "[^a-zA-Z0-9_]", "_");
}
