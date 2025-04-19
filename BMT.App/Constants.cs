namespace BMT.App;

public static class Constants
{
    public const string DatabaseFilename = "BMTData.db";

    public const SQLite.SQLiteOpenFlags Flags =
        // open the database in read/write mode
        SQLite.SQLiteOpenFlags.ReadWrite |
        // create the database if it doesn't exist
        SQLite.SQLiteOpenFlags.Create |
        // enable multi-threaded database access
        SQLite.SQLiteOpenFlags.SharedCache;

    private static string _databasePath = Path.Combine(FileSystem.AppDataDirectory, DatabaseFilename);

    public static string DatabasePath
    {
        get => _databasePath;
        set
        {
            if (!string.IsNullOrWhiteSpace(value))
            {
                _databasePath = value;
            }
        }
    }
}
