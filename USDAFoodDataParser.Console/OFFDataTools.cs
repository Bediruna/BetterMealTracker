using MongoDB.Bson;
using MongoDB.Driver;

public static class OFFDataTools
{
    const string databaseName = "off";

    const string collectionName = "products";

    public async static Task TestDb()
    {
        var client = new MongoClient();

        var database = client.GetDatabase(databaseName);

        var collection = database.GetCollection<BsonDocument>(collectionName);

        var firstDocument = await collection.Find(new BsonDocument()).FirstOrDefaultAsync();

        Console.WriteLine(firstDocument.ToJson());
    }
}
