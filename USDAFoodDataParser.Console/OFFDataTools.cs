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

    public async static Task SaveProductsToDb()
    {
        try
        {
            var client = new MongoClient();
            var database = client.GetDatabase(databaseName);
            var collection = database.GetCollection<BsonDocument>(collectionName);
            var dbPath = Path.Combine(@"C:\Users\bedir\Downloads", "off.db");

            // Define batch size
            const int batchSize = 1000;

            // Get the last processed ID from SQLite
            string lastProcessedId = null;

            var db = new SQLiteAsyncConnection(dbPath);
            await db.CreateTableAsync<OffDetails>();

            var lastProduct = await db.Table<OffDetails>()
                              .OrderByDescending(p => p.OffId)
                              .FirstOrDefaultAsync();

            if (lastProduct != null)
            {
                lastProcessedId = lastProduct.OffId;
                var count = await db.Table<OffDetails>().CountAsync();
                Console.WriteLine($"Resuming from previous run. Already processed: {count} documents");
            }

            // Initialize variables for batching
            long processedCount = 0;
            long skippedCount = 0;
            bool hasMoreData = true;

            // Use SortBy to ensure consistent pagination
            var sort = Builders<BsonDocument>.Sort.Ascending("id");

            while (hasMoreData)
            {
                // Build filter for the next batch
                var filter = Builders<BsonDocument>.Filter.Empty;
                if (!string.IsNullOrEmpty(lastProcessedId))
                {
                    // Using the correct field name "id" from your mapper
                    filter = Builders<BsonDocument>.Filter.Gt("id", lastProcessedId);
                }

                // Get the next batch
                var batchCursor = collection.Find(filter)
                                          .Sort(sort)
                                          .Limit(batchSize);

                var batch = await batchCursor.ToListAsync();

                if (batch.Count == 0)
                {
                    hasMoreData = false;
                    continue;
                }

                // Process this batch, filtering out products with no name
                var productsToStore = batch.Select(p => MapToProductInfo(p))
                                          .Where(p => !string.IsNullOrWhiteSpace(p.ProductName))
                                          .ToList();

                skippedCount += (batch.Count - productsToStore.Count);

                if (productsToStore.Count > 0)
                {
                    await db.RunInTransactionAsync(conn =>
                    {
                        conn.InsertAll(productsToStore);
                    });

                }

                // Keep track of progress
                processedCount += productsToStore.Count;
                Console.WriteLine($"Processed {processedCount} documents, skipped {skippedCount} without product names");

                // Update the last processed ID using the actual field name
                if (batch.Last().Contains("id"))
                {
                    lastProcessedId = batch.Last()["if"].AsString;
                }
                else
                {
                    Console.WriteLine("Warning: Document doesn't contain 'id' field");
                    hasMoreData = false;
                }
            }

            Console.WriteLine($"Completed processing {processedCount} documents");
            Console.WriteLine($"Skipped {skippedCount} documents with no product name");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Database save error: {ex.Message}");
            Console.WriteLine($"Stack trace: {ex.StackTrace}");
        }
    }
}
