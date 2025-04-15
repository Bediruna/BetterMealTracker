using MongoDB.Bson;
using MongoDB.Driver;
using SQLite;

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

    public static OffDetails MapToProductInfo(BsonDocument document)
    {
        var product = new OffDetails();

        // Simple fields
        if (ValidValue(document, "_id")) product.OffId = document["_id"].ToString();
        if (ValidValue(document, "product_name")) product.ProductName = document["product_name"].ToString();
        if (ValidValue(document, "brands")) product.Brands = document["brands"].ToString();
        if (ValidValue(document, "ingredients_text")) product.Ingredients = document["ingredients_text"].ToString();

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

        if (ValidValue(document, "quantity")) product.Quantity = document["quantity"].ToString();
        if (ValidValue(document, "product_quantity")) product.ProductQuantity = Convert.ToDouble(document["product_quantity"]);
        if (ValidValue(document, "product_quantity_unit")) product.ProductQuantityUnit = document["product_quantity_unit"].ToString();
        if (ValidValue(document, "serving_size")) product.ServingSize = document["serving_size"].ToString();
        if (ValidValue(document, "serving_quantity")) product.ServingQuantity = Convert.ToDouble(document["serving_quantity"]);
        if (ValidValue(document, "serving_quantity_unit")) product.ServingQuantityUnit = document["serving_quantity_unit"].ToString();

        return product;
    }

    public async static Task SaveProductsToDb()
    {
        try
        {
            var client = new MongoClient();
            var database = client.GetDatabase(databaseName);
            var collection = database.GetCollection<BsonDocument>(collectionName);
            var dbPath = Path.Combine(@"C:\Users\bedir\Downloads", "off.db");

            const int batchSize = 1000;
            var db = new SQLiteAsyncConnection(dbPath);
            await db.CreateTableAsync<OffDetails>();

            bool hasMoreData = true;
            // Get the last added OffId from the SQLite database
            var lastRecord = await db.Table<OffDetails>()
                .OrderByDescending(x => x.Id)
                .FirstOrDefaultAsync();
            string lastId = lastRecord?.OffId ?? "";

            int totalAdded = 0;

            while (hasMoreData)
            {
                var filter = string.IsNullOrEmpty(lastId)
                    ? Builders<BsonDocument>.Filter.Empty
                    : Builders<BsonDocument>.Filter.Gt("_id", lastId);

                var sort = Builders<BsonDocument>.Sort.Ascending("_id");

                var batch = await collection.Find(filter)
                                            .Sort(sort)
                                            .Limit(batchSize)
                                            .ToListAsync();

                if (batch.Count == 0)
                {
                    hasMoreData = false;
                    continue;
                }

                var productsToStore = batch.Select(p => MapToProductInfo(p))
                                           .Where(p => !string.IsNullOrWhiteSpace(p.ProductName))
                                           .ToList();

                if (productsToStore.Count > 0)
                {
                    var offIds = productsToStore.Select(p => p.OffId).ToList();
                    var existing = await db.Table<OffDetails>()
                        .Where(x => offIds.Contains(x.OffId))
                        .ToListAsync();
                    var existingIds = new HashSet<string>(existing.Select(x => x.OffId));
                    var newProducts = productsToStore.Where(p => !existingIds.Contains(p.OffId)).ToList();

                    if (newProducts.Count > 0)
                    {
                        await db.RunInTransactionAsync(conn =>
                        {
                            conn.InsertAll(newProducts);
                        });
                        totalAdded += newProducts.Count;
                        Console.WriteLine($"Added {newProducts.Count} products in this batch. Total added so far: {totalAdded}");
                    }
                    else
                    {
                        Console.WriteLine($"No new products to add in this batch. Total added so far: {totalAdded}");
                    }
                }
                else
                {
                    Console.WriteLine($"No valid products to store in this batch. Total added so far: {totalAdded}");
                }

                lastId = batch.Last()["_id"].ToString();
            }
            Console.WriteLine($"Finished! Total new products added: {totalAdded}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Database save error: {ex.Message}");
            Console.WriteLine($"Stack trace: {ex.StackTrace}");
        }
    }
}
