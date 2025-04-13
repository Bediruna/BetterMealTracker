using SQLite;

public static class SQLitePCLHelper
{
    static SQLiteAsyncConnection db;

    public static async Task InitAsync(string dbPath = "off.db")
    {
        if (db != null) return;

        var path = Path.Combine(Environment.CurrentDirectory, dbPath);
        db = new SQLiteAsyncConnection(path);
        await db.CreateTableAsync<OffDetails>();
    }

    public static async Task SaveProductsAsync(List<OffDetails> products)
    {
        await InitAsync();
        foreach (var p in products)
        {
            await db.InsertOrReplaceAsync(p);
        }
    }

    public static async Task<List<OffDetails>> GetAllProductsAsync()
    {
        await InitAsync();
        return await db.Table<OffDetails>().ToListAsync();
    }
}
