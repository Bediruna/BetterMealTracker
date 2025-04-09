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
            Task.Run(InitializeDatabase).Wait();
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
                await db.CreateTableAsync<ServingOption>();
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

    public async Task<List<FoodLog>> GetAllLogs()
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

    public async Task<List<FoodLog>> GetLogsForExercise(int exerciseId)
    {
        try
        {
            var results = await db.Table<FoodLog>()
                                  .Where(log => log.FoodId == exerciseId)
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

    public async Task<List<FoodLog>> GetLogsForExerciseAndSelectedDate(int exerciseId)
    {
        try
        {
            var startDate = new DateTime(SelectedDate.Year, SelectedDate.Month, SelectedDate.Day);
            var nextDay = startDate.AddDays(1);

            var results = await db.Table<FoodLog>()
                                  .Where(log => log.FoodId == exerciseId &&
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

    public async Task<List<FoodLog>> DeleteExerciseAndReturnUpdatedLogs(FoodLog exerciseToDelete)
    {
        var updatedLogsForTheDay = new List<FoodLog>();
        try
        {
            // Define the date range of interest
            var dateOfExercise = exerciseToDelete.DateConsumed;

            // Delete the exercise
            await db.DeleteAsync(exerciseToDelete);

            // Retrieve and update the OrderInDay for remaining exercises on the same day
            var exercisesForTheDay = await GetLogsForExerciseAndSelectedDate(exerciseToDelete.Id);

            int updatedOrder = 1; // Start reordering from 1
            foreach (var exercise in exercisesForTheDay)
            {
                if (exercise.Id != exerciseToDelete.Id) // Skip the deleted exercise (if it's still in the list due to async timing)
                {
                    await db.UpdateAsync(exercise);
                }
            }

            // Retrieve the updated list of logs for that day
            updatedLogsForTheDay = await GetLogsForExerciseAndSelectedDate(exerciseToDelete.Id);
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
}