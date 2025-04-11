using MongoDB.Bson;
using MongoDB.Driver;

public static class OFFDataTools
{
    const string databaseName = "off";
    const string collectionName = "products";

    private static bool ShouldPrintValue(BsonDocument document, string fieldName)
    {
        if (!document.Contains(fieldName)) return false;
        
        var value = document[fieldName];
        if (value.IsString) return value.AsString != "";
        if (value.IsDouble) return value.AsDouble != 0;
        if (value.IsInt32) return value.AsInt32 != 0;
        if (value.IsInt64) return value.AsInt64 != 0;
        return false;
    }

    public async static Task PrintValues(string documentJson)
    {
        var document = BsonDocument.Parse(documentJson);

        Console.WriteLine("\nExtracted values:");
        if (ShouldPrintValue(document, "product_name")) Console.WriteLine($"Product Name: {document["product_name"]}");
        if (ShouldPrintValue(document, "brands")) Console.WriteLine($"Brands: {document["brands"]}");
        if (ShouldPrintValue(document, "ingredients_text")) Console.WriteLine($"Ingredients: {document["ingredients_text"]}");

        if (document.Contains("nutriments"))
        {
            var nutriments = document["nutriments"].AsBsonDocument;
            if (ShouldPrintValue(nutriments, "energy-kcal_100g")) Console.WriteLine($"Calories: {nutriments["energy-kcal_100g"]}");
            if (ShouldPrintValue(nutriments, "proteins_100g")) Console.WriteLine($"Protein: {nutriments["proteins_100g"]}");
            if (ShouldPrintValue(nutriments, "fat_100g")) Console.WriteLine($"Fat: {nutriments["fat_100g"]}");
            if (ShouldPrintValue(nutriments, "saturated-fat_100g")) Console.WriteLine($"Saturated Fat: {nutriments["saturated-fat_100g"]}");
            if (ShouldPrintValue(nutriments, "trans-fat_100g")) Console.WriteLine($"TransFatG: {nutriments["trans-fat_100g"]}g");
            if (ShouldPrintValue(nutriments, "carbohydrates_100g")) Console.WriteLine($"CarbsG: {nutriments["carbohydrates_100g"]}g");
            if (ShouldPrintValue(nutriments, "fiber_100g")) Console.WriteLine($"FiberG: {nutriments["fiber_100g"]}g");
            if (ShouldPrintValue(nutriments, "sugars_100g")) Console.WriteLine($"SugarG: {nutriments["sugars_100g"]}g");
            if (ShouldPrintValue(nutriments, "added-sugars_100g")) Console.WriteLine($"AddedSugarG: {nutriments["added-sugars_100g"]}g");

            // --- Minerals & Cholesterol ---
            if (ShouldPrintValue(nutriments, "cholesterol_100g")) Console.WriteLine($"CholesterolMg: {nutriments["cholesterol_100g"]}mg");
            if (ShouldPrintValue(nutriments, "sodium_100g")) Console.WriteLine($"SodiumMg: {nutriments["sodium_100g"]}g (Value in g, multiply by 1000 for mg)");
            if (ShouldPrintValue(nutriments, "potassium_100g")) Console.WriteLine($"PotassiumMg: {nutriments["potassium_100g"]}mg");
            if (ShouldPrintValue(nutriments, "calcium_100g")) Console.WriteLine($"CalciumMg: {nutriments["calcium_100g"]}mg");
            if (ShouldPrintValue(nutriments, "iron_100g")) Console.WriteLine($"IronMg: {nutriments["iron_100g"]}mg");
            if (ShouldPrintValue(nutriments, "magnesium_100g")) Console.WriteLine($"MagnesiumMg: {nutriments["magnesium_100g"]}mg");
            if (ShouldPrintValue(nutriments, "zinc_100g")) Console.WriteLine($"ZincMg: {nutriments["zinc_100g"]}mg");

            // --- Vitamins ---
            if (ShouldPrintValue(nutriments, "vitamin-a_100g")) Console.WriteLine($"VitaminAug: {nutriments["vitamin-a_100g"]}µg");
            if (ShouldPrintValue(nutriments, "vitamin-c_100g")) Console.WriteLine($"VitaminCMg: {nutriments["vitamin-c_100g"]}mg");
            if (ShouldPrintValue(nutriments, "vitamin-d_100g")) Console.WriteLine($"VitaminDug: {nutriments["vitamin-d_100g"]}µg");
            if (ShouldPrintValue(nutriments, "vitamin-b12_100g")) Console.WriteLine($"VitaminB12ug: {nutriments["vitamin-b12_100g"]}µg");
        }
        else
        {
            Console.WriteLine("No nutriments found in document");
        }
    }

    public async static Task SearchProducts(string searchTerm)
    {
        var client = new MongoClient();
        var database = client.GetDatabase(databaseName);
        var collection = database.GetCollection<BsonDocument>(collectionName);

        var filter = Builders<BsonDocument>.Filter.Regex("product_name", new BsonRegularExpression(searchTerm, "i"));
        var products = await collection.Find(filter).Limit(5).ToListAsync();

        if (products.Count > 0)
        {
            Console.WriteLine($"Found {products.Count} products matching '{searchTerm}':\n");
            
            foreach (var product in products)
            {
                Console.WriteLine("----------------------------------------");
                await PrintValues(product.ToJson());
            }
        }
        else
        {
            Console.WriteLine($"No products found matching '{searchTerm}'");
        }
    }
}
