namespace FoodDataImporter;

class Program
{
    public static readonly string DirectoryPath = @"C:\Users\bedir\Downloads\FoodData";
    static readonly string USDAFoodDataConStr =
        Environment.GetEnvironmentVariable("PG_usdafooddata_CONN_STRING")
        ?? throw new InvalidOperationException("PG_usdafooddata_CONN_STRING not set");

    static async Task Main(string[] args)
    {

    }
}