using BMT.Data.Models;
using SQLite;
namespace BMT.App.Services;

public class DataService
{
    public SQLiteAsyncConnection db;
    private static bool isInitialized = false;
    public DateTime SelectedDate { get; set; } = DateTime.Now;

    public DataService()
    {
        try
        {
            Task.Run(async () =>
            {
                await CopyDatabaseIfNotExists();
                await InitializeDatabase();
            }).Wait();
        }
        catch (Exception ex)
        {
            LogError(ex);
        }
    }

    private async Task InitializeDatabase()
    {
        if (!isInitialized)
        {
            try
            {
                db = new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags, true);

                await db.CreateTableAsync<Food>();
                await db.CreateTableAsync<FoodLog>();
                await db.CreateTableAsync<MealType>();
                await db.CreateTableAsync<VisibleOnLogPage>();
                await db.CreateTableAsync<VisibleOnMainPage>();
                await db.CreateTableAsync<ErrorLog>();                

                isInitialized = true;
            }
            catch (Exception ex)
            {
                await LogError(ex);
            }
        }
    }

    public async Task<List<FoodLog>> GetAllFoods()
    {
        try
        {
            var results = await db.Table<FoodLog>().ToListAsync();

            return results;
        }
        catch (Exception ex)
        {
            await LogError(ex);
            return [];
        }
    }

    public async Task<List<FoodLog>> GetLogsForSelectedDate()
    {
        try
        {
            var startDate = new DateTime(SelectedDate.Year, SelectedDate.Month, SelectedDate.Day);
            var nextDay = startDate.AddDays(1);

            var results = await db.Table<FoodLog>()
                                  .Where(log => log.DateConsumed >= startDate && log.DateConsumed < nextDay)
                                  .OrderByDescending(log => log.DateConsumed)
                                  .ToListAsync();

            return results;
        }
        catch (Exception ex)
        {
            await LogError(ex);
            return [];
        }
    }

    public async Task<List<FoodLog>> GetLogsForFood(int foodId)
    {
        try
        {
            var results = await db.Table<FoodLog>()
                                  .Where(log => log.FoodId == foodId)
                                  .OrderByDescending(log => log.DateConsumed)
                                  .ToListAsync();

            return results;
        }
        catch (Exception ex)
        {
            await LogError(ex);
            return [];
        }
    }

    public async Task<List<FoodLog>> GetLogsForFoodAndSelectedDate(int foodId)
    {
        try
        {
            var startDate = new DateTime(SelectedDate.Year, SelectedDate.Month, SelectedDate.Day);
            var nextDay = startDate.AddDays(1);

            var results = await db.Table<FoodLog>()
                                  .Where(log => log.FoodId == foodId &&
                                                log.DateConsumed >= startDate &&
                                                log.DateConsumed < nextDay)
                                  .OrderByDescending(log => log.DateConsumed)
                                  .ToListAsync();

            return results;
        }
        catch (Exception ex)
        {
            await LogError(ex);
            return [];
        }
    }

    public async Task<List<FoodLog>> DeleteFoodAndReturnUpdatedLogs(FoodLog foodToDelete)
    {
        var updatedLogsForTheDay = new List<FoodLog>();
        try
        {
            // Define the date range of interest
            var dateOfFood = foodToDelete.DateConsumed;

            // Delete the food
            await db.DeleteAsync(foodToDelete);

            // Retrieve and update the OrderInDay for remaining foods on the same day
            var foodsForTheDay = await GetLogsForFoodAndSelectedDate(foodToDelete.Id);

            int updatedOrder = 1; // Start reordering from 1
            foreach (var food in foodsForTheDay)
            {
                if (food.Id != foodToDelete.Id) // Skip the deleted food (if it's still in the list due to async timing)
                {
                    await db.UpdateAsync(food);
                }
            }

            // Retrieve the updated list of logs for that day
            updatedLogsForTheDay = await GetLogsForFoodAndSelectedDate(foodToDelete.Id);
        }
        catch (Exception ex)
        {
            await LogError(ex);
        }

        return updatedLogsForTheDay;
    }

    private async Task LogError(Exception exception)
    {
        try
        {
            Console.WriteLine($"Error: {exception}");
            var errorLog = new ErrorLog()
            {
                ErrorMessage = exception.ToString(),
                ErrorDateTime = DateTime.Now
            };
            await db.InsertAsync(errorLog);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Failed to log error because: " + ex.ToString());
        }
    }
    private async Task CopyDatabaseIfNotExists()
    {
        var destinationPath = Path.Combine(FileSystem.AppDataDirectory, "off.db");

        if (!File.Exists(destinationPath))
        {
            using var stream = await FileSystem.OpenAppPackageFileAsync("off.db");
            using var destinationStream = File.Create(destinationPath);
            await stream.CopyToAsync(destinationStream);
        }

        Constants.DatabasePath = destinationPath; // Update the database path
    }
    public async Task<List<Food>> SearchFoods(string query)
    {
        try
        {
            string sqlQuery = $"SELECT * FROM Food WHERE Name LIKE '%{query}%'";
            return await db.QueryAsync<Food>(sqlQuery);
        }
        catch (Exception ex)
        {
            await LogError(ex);
            return new List<Food>();
        }
    }

    public async Task<List<Food>> GetMostRecentlyUsedFoods(int count)
    {
        try
        {
            return await db.Table<Food>()
                           .OrderByDescending(food => food.LastUsedDate)
                           .Take(count)
                           .ToListAsync();
        }
        catch (Exception ex)
        {
            await LogError(ex);
            return new List<Food>();
        }
    }

}