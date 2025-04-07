using CsvHelper;
using System.Globalization;
using System.Collections.Generic;
using System.IO;
using System.Linq;

var foodFile = "food.csv";
var brandedFile = "branded_food.csv";
var nutrientFile = "food_nutrient.csv";

var foodDescriptions = new Dictionary<int, string>();
var brandedMap = new Dictionary<int, string>();
var foodList = new Dictionary<int, Food>();

// Load food.csv
using (var reader = new StreamReader(foodFile))
using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
{
    var records = csv.GetRecords<dynamic>();
    foreach (var row in records)
    {
        int fdcId = int.Parse(row.fdc_id);
        string name = row.description;
        foodDescriptions[fdcId] = name;

        foodList[fdcId] = new Food
        {
            FoodId = fdcId,
            Name = name
        };
    }
}

// Load branded_food.csv for brand names
using (var reader = new StreamReader(brandedFile))
using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
{
    var records = csv.GetRecords<dynamic>();
    foreach (var row in records)
    {
        if (int.TryParse(row.fdc_id, out int fdcId) && row.brand_owner != null)
        {
            brandedMap[fdcId] = row.brand_owner;
        }
    }
}

// Apply brand to foods
foreach (var kvp in brandedMap)
{
    if (foodList.TryGetValue(kvp.Key, out var food))
    {
        food.Brand = kvp.Value;
    }
}

// Nutrient ID map
var nutrientMap = new Dictionary<int, Action<Food, float>> {
    { 1008, (f,v) => f.Calories = v },
    { 1003, (f,v) => f.ProteinG = v },
    { 1004, (f,v) => f.FatG = v },
    { 1258, (f,v) => f.SaturatedFatG = v },
    { 1253, (f,v) => f.TransFatG = v },
    { 1005, (f,v) => f.CarbsG = v },
    { 1079, (f,v) => f.FiberG = v },
    { 2000, (f,v) => f.SugarG = v },
    { 1235, (f,v) => f.AddedSugarG = v },
    { 1253, (f,v) => f.CholesterolMg = v },
    { 1093, (f,v) => f.SodiumMg = v },
    { 1092, (f,v) => f.PotassiumMg = v },
    { 1087, (f,v) => f.CalciumMg = v },
    { 1089, (f,v) => f.IronMg = v },
    { 1106, (f,v) => f.VitaminA_µg = v },
    { 1162, (f,v) => f.VitaminC_Mg = v },
    { 1114, (f,v) => f.VitaminD_µg = v },
    { 1178, (f,v) => f.VitaminB12_µg = v },
    { 304,  (f,v) => f.MagnesiumMg = v },
    { 1095, (f,v) => f.ZincMg = v }
};

// Load nutrients
using (var reader = new StreamReader(nutrientFile))
using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
{
    var records = csv.GetRecords<dynamic>();
    foreach (var row in records)
    {
        int fdcId = int.Parse(row.fdc_id);
        int nutrientId = int.Parse(row.nutrient_id);
        if (!float.TryParse(row.amount, out float value)) continue;

        if (foodList.TryGetValue(fdcId, out var food) && nutrientMap.TryGetValue(nutrientId, out var setter))
        {
            setter(food, value);
        }
    }
}

// Now foodList.Values contains all enriched Food entries
foreach (var food in foodList.Values)
{
    Console.WriteLine($"{food.FoodId}, {food.Name}, {food.Brand}, Calories: {food.Calories}");
}
