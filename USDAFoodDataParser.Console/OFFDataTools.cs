using MongoDB.Bson;
using MongoDB.Driver;

public static class OFFDataTools
{
    const string databaseName = "off";
    const string collectionName = "products";

    static bool ValidValue(BsonDocument document, string fieldName)
    {
        if (!document.Contains(fieldName)) return false;

        var value = document[fieldName];
        if (value.IsString) return value.AsString != "";
        if (value.IsDouble) return value.AsDouble != 0;
        if (value.IsInt32) return value.AsInt32 != 0;
        if (value.IsInt64) return value.AsInt64 != 0;

        return false;
    }

    static void PrintValue(BsonDocument document, string fieldName, string label = "", string suffix = "")
    {
        if (!ValidValue(document, fieldName)) return;
        if (string.IsNullOrEmpty(label)) label = fieldName;

        var value = document[fieldName];
        string output;

        if (value.IsDouble || value.IsDecimal128 || value.IsInt32 || value.IsInt64)
        {
            output = Math.Round(Convert.ToDouble(value), 2).ToString("0.##");
        }
        else
        {
            output = value.ToString();
        }

        Console.WriteLine($"{label}: {output}{suffix}");
    }


    public async static Task PrintValues(string documentJson)
    {
        var document = BsonDocument.Parse(documentJson);

        Console.WriteLine("----------------------------------------");

        PrintValue(document, "id");
        PrintValue(document, "product_name", "Product Name");
        PrintValue(document, "brands", "Brands");
        PrintValue(document, "ingredients_text", "Ingredients");

        if (document.Contains("nutriments"))
        {
            var n = document["nutriments"].AsBsonDocument;

            PrintValue(n, "energy-kcal_100g", "Calories");
            PrintValue(n, "proteins_100g", "Protein");
            PrintValue(n, "fat_100g", "Fat");
            PrintValue(n, "saturated-fat_100g", "Saturated Fat");
            PrintValue(n, "trans-fat_100g", "TransFatG", "g");
            PrintValue(n, "carbohydrates_100g", "CarbsG", "g");
            PrintValue(n, "fiber_100g", "FiberG", "g");
            PrintValue(n, "sugars_100g", "SugarG", "g");
            PrintValue(n, "added-sugars_100g", "AddedSugarG", "g");

            PrintValue(n, "cholesterol_100g", "CholesterolMg", "mg");
            PrintValue(n, "sodium_100g", "SodiumMg", "g");
            PrintValue(n, "potassium_100g", "PotassiumMg", "mg");
            PrintValue(n, "calcium_100g", "CalciumMg", "mg");
            PrintValue(n, "iron_100g", "IronMg", "mg");
            PrintValue(n, "magnesium_100g", "MagnesiumMg", "mg");
            PrintValue(n, "zinc_100g", "ZincMg", "mg");

            PrintValue(n, "vitamin-a_100g", "VitaminAug", "µg");
            PrintValue(n, "vitamin-c_100g", "VitaminCMg", "mg");
            PrintValue(n, "vitamin-d_100g", "VitaminDug", "µg");
            PrintValue(n, "vitamin-b12_100g", "VitaminB12ug", "µg");

            PrintValue(document, "quantity");
            PrintValue(document, "product_quantity");
            PrintValue(document, "product_quantity_unit");
            PrintValue(document, "serving_size");
            PrintValue(document, "serving_quantity");
            PrintValue(document, "serving_quantity_unit");
        }
        else
        {
            Console.WriteLine("No nutriments found in document");
        }
    }

    public static OffDetails MapToProductInfo(BsonDocument document)
    {
        var product = new OffDetails();

        // Simple fields
        if (ValidValue(document, "id")) product.OffId = document["id"].AsString;
        if (ValidValue(document, "product_name")) product.ProductName = document["product_name"].AsString;
        if (ValidValue(document, "brands")) product.Brands = document["brands"].AsString;
        if (ValidValue(document, "ingredients_text")) product.Ingredients = document["ingredients_text"].AsString;

        if (document.Contains("nutriments"))
        {
            var n = document["nutriments"].AsBsonDocument;

            double? GetDouble(string field) => ValidValue(n, field) ? (double?)Convert.ToDouble(n[field]) : null;

            product.Calories = GetDouble("energy-kcal_100g");
            product.Protein = GetDouble("proteins_100g");
            product.Fat = GetDouble("fat_100g");
            product.SaturatedFat = GetDouble("saturated-fat_100g");
            product.TransFatG = GetDouble("trans-fat_100g");
            product.CarbsG = GetDouble("carbohydrates_100g");
            product.FiberG = GetDouble("fiber_100g");
            product.SugarG = GetDouble("sugars_100g");
            product.AddedSugarG = GetDouble("added-sugars_100g");

            product.CholesterolMg = GetDouble("cholesterol_100g");
            product.SodiumMg = GetDouble("sodium_100g");
            product.PotassiumMg = GetDouble("potassium_100g");
            product.CalciumMg = GetDouble("calcium_100g");
            product.IronMg = GetDouble("iron_100g");
            product.MagnesiumMg = GetDouble("magnesium_100g");
            product.ZincMg = GetDouble("zinc_100g");

            product.VitaminAug = GetDouble("vitamin-a_100g");
            product.VitaminCMg = GetDouble("vitamin-c_100g");
            product.VitaminDug = GetDouble("vitamin-d_100g");
            product.VitaminB12ug = GetDouble("vitamin-b12_100g");
        }

        if (ValidValue(document, "quantity")) product.Quantity = document["quantity"].AsString;
        if (ValidValue(document, "product_quantity")) product.ProductQuantity = Convert.ToDouble(document["product_quantity"]);
        if (ValidValue(document, "product_quantity_unit")) product.ProductQuantityUnit = document["product_quantity_unit"].AsString;
        if (ValidValue(document, "serving_size")) product.ServingSize = document["serving_size"].AsString;
        if (ValidValue(document, "serving_quantity")) product.ServingQuantity = Convert.ToDouble(document["serving_quantity"]);
        if (ValidValue(document, "serving_quantity_unit")) product.ServingQuantityUnit = document["serving_quantity_unit"].AsString;

        return product;
    }


    public async static Task SearchProductsLimited(string searchTerm, int limit = 5)
    {
        var productsToStore = new List<OffDetails>();
        try
        {
            var client = new MongoClient();

            var database = client.GetDatabase(databaseName);
            var collection = database.GetCollection<BsonDocument>(collectionName);

            var regex = new BsonRegularExpression(searchTerm, "i");

            var filter = Builders<BsonDocument>.Filter.Or(
                Builders<BsonDocument>.Filter.Regex("product_name", regex),
                Builders<BsonDocument>.Filter.Regex("brands", regex)
            );

            var products = await collection.Find(filter)
                .Limit(limit)
                .ToListAsync();

            Console.WriteLine($"Found {products.Count} products matching '{searchTerm}':\n");

            foreach (var product in products)
            {
                await PrintValues(product.ToJson(new MongoDB.Bson.IO.JsonWriterSettings { Indent = true }));
                var details = MapToProductInfo(product);
                productsToStore.Add(details);
            }


        }
        catch (Exception ex)
        {
            Console.WriteLine($"An unexpected error occurred: {ex.Message}");
        }
    }

}
