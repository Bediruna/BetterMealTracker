using CsvHelper;
using Npgsql;
using System.Globalization;
using System.Text.RegularExpressions;

namespace FoodDataImporter;

partial class Program
{
    static async Task ProcessFoodDataAsync()
    {
        var csvFiles = Directory.GetFiles(DirectoryPath, "*.csv");

        using var connection = new NpgsqlConnection(USDAFoodDataConStr);
        await connection.OpenAsync();

        foreach (var filePath in csvFiles)
        {
            var tableName = Path.GetFileNameWithoutExtension(filePath).ToLowerInvariant();

            // 1. Read Headers and Sanitize
            string[] headers;
            using (var headerReader = new StreamReader(filePath))
            using (var csvHeaderReader = new CsvReader(headerReader, CultureInfo.InvariantCulture))
            {
                await csvHeaderReader.ReadAsync();
                csvHeaderReader.ReadHeader();
                headers = csvHeaderReader.HeaderRecord!;
            }
            var sanitizedHeaders = headers.Select(SanitizeHeader).ToArray();

            // 2. Create Table If Not Exists
            var columnDefinitions = string.Join(", ", sanitizedHeaders.Select(h => $"\"{h}\" TEXT"));
            var createTableSql = $"CREATE TABLE IF NOT EXISTS \"{tableName}\" ({columnDefinitions});";
            using (var createCommand = new NpgsqlCommand(createTableSql, connection))
            {
                await createCommand.ExecuteNonQueryAsync();
            }

            // 3. Import Data
            using var dataReader = new StreamReader(filePath);
            using var csvDataReader = new CsvReader(dataReader, CultureInfo.InvariantCulture);
            await csvDataReader.ReadAsync();
            csvDataReader.ReadHeader();

            using var writer = connection.BeginBinaryImport(
                $"COPY \"{tableName}\" ({string.Join(", ", sanitizedHeaders.Select(h => $"\"{h}\""))}) FROM STDIN (FORMAT BINARY)"
            );

            while (await csvDataReader.ReadAsync())
            {
                writer.StartRow();
                foreach (var header in headers)
                {
                    var value = csvDataReader.GetField(header);
                    await writer.WriteAsync(string.IsNullOrWhiteSpace(value) ? null : value, NpgsqlTypes.NpgsqlDbType.Text);
                }
            }
            await writer.CompleteAsync();

            Console.WriteLine($"Inserted rows into {tableName}");
        }
    }

    static string SanitizeHeader(string input)
    {
        return Regex.Replace(input, "[^a-zA-Z0-9_]", "_");
    }
}