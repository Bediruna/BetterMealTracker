using BMT.Data.Models;
using CsvHelper;
using Dapper;
using Npgsql;
using System.Globalization;
using System.Reflection;
using System.Text.RegularExpressions;

class USDAFoodDataTools
{

    public static readonly string DirectoryPath = @"C:\Users\bedir\Documents\FoodData";
    static readonly string USDAFoodDataConStr =
        Environment.GetEnvironmentVariable("PG_usdafooddata_CONN_STRING")
        ?? throw new InvalidOperationException("PG_usdafooddata_CONN_STRING not set");

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


    static async Task CreateDatabaseTables()
    {
        using var connection = new NpgsqlConnection(USDAFoodDataConStr);
        await connection.OpenAsync();

        await CreateTableForClassAsync<Food>(connection);
        await CreateTableForClassAsync<ServingOption>(connection);

        Console.WriteLine("Database table creation completed.");
    }

    static async Task CreateTableForClassAsync<T>(NpgsqlConnection connection) where T : class
    {
        var type = typeof(T);
        var tableName = $"\"better_{type.Name}\""; // Quote the table name
        var sqlBuilder = new System.Text.StringBuilder();

        sqlBuilder.AppendLine($"CREATE TABLE IF NOT EXISTS {tableName} (");

        sqlBuilder.AppendLine("    \"Id\" SERIAL PRIMARY KEY,");

        var properties = type.GetProperties(BindingFlags.Public | BindingFlags.Instance)
                            .Where(p => p.Name != "Id").ToList();

        for (int i = 0; i < properties.Count; i++)
        {
            var prop = properties[i];
            var columnName = prop.Name;
            var columnType = GetSqlType(prop.PropertyType) ?? "TEXT";
            var notNull = prop.GetCustomAttributes(typeof(System.ComponentModel.DataAnnotations.RequiredAttribute), true).Any() ? " NOT NULL" : "";
            sqlBuilder.AppendLine($"    \"{columnName}\" {columnType}{notNull}{(i < properties.Count - 1 ? "," : "")}"); // Quote the column name
        }

        sqlBuilder.AppendLine("\n);");

        var createTableSql = sqlBuilder.ToString();

        Console.WriteLine($"Executing SQL for table '{tableName}':\n{createTableSql}");
        await connection.ExecuteAsync(createTableSql);
    }

    static string? GetSqlType(Type propertyType)
    {
        propertyType = Nullable.GetUnderlyingType(propertyType) ?? propertyType;

        return propertyType switch
        {
            { } t when t == typeof(int) => "INTEGER",
            { } t when t == typeof(long) => "BIGINT",
            { } t when t == typeof(float) => "REAL",
            { } t when t == typeof(double) => "DOUBLE PRECISION",
            { } t when t == typeof(decimal) => "NUMERIC",
            { } t when t == typeof(bool) => "BOOLEAN",
            { } t when t == typeof(DateTime) => "TIMESTAMP",
            { } t when t == typeof(Guid) => "UUID",
            _ => null
        };
    }
}