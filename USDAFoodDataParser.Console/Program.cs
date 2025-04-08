using System.Globalization;
using CsvHelper;
using Dapper;
using Npgsql;

var path = @"C:\Users\bedir\Downloads\FoodData\food.csv";
string connString = Environment.GetEnvironmentVariable("PG_TEST_CONN_STRING") ?? throw new InvalidOperationException("PG_TEST_CONN_STRING not set");

var conn = new NpgsqlConnection(connString);

//using var reader = new StreamReader(path);
//using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
//var records = csv.GetRecords<dynamic>();

//foreach (var row in records)
//{
//   // Console.WriteLine($"{row.fdc_id}, {row.description}");
//}

var users = await conn.QueryAsync<dynamic>("SELECT * FROM users");

foreach (var user in users)
{
    Console.WriteLine($"{user.id}, {user.username}");
}