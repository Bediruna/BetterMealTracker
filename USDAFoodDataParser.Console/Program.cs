using BMT.Data.Models;
using Dapper;
using Npgsql;
using System.Reflection;

namespace FoodDataImporter;

partial class Program
{
    public static readonly string DirectoryPath = @"C:\Users\bedir\Downloads\FoodData";
    static readonly string USDAFoodDataConStr =
        Environment.GetEnvironmentVariable("PG_usdafooddata_CONN_STRING")
        ?? throw new InvalidOperationException("PG_usdafooddata_CONN_STRING not set");

    static async Task Main(string[] args)
    {
        await CreateDatabaseTables();
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