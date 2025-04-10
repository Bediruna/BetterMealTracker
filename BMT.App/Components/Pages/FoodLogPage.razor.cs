using BMT.App.Services;
using BMT.Data.Models;
using Microsoft.AspNetCore.Components;

namespace BMT.App.Components.Pages;
public partial class FoodLogPage : ComponentBase
{

    [Inject]
    private DataService dataService { get; set; }

    [Parameter]
    public int ExerciseId { get; set; }

    private Food food;
    private FoodLog selectedLog = new();
    private List<FoodLog> foodLogs = [];
    private List<FoodLog> logsForSelectedDate = [];

    private string errorMessage;

    protected override async Task OnInitializedAsync()
    {
        food = await dataService.db.GetAsync<Food>(ExerciseId);
        foodLogs = await dataService.GetLogsForExercise(ExerciseId);

        logsForSelectedDate = await dataService.GetLogsForExerciseAndSelectedDate(ExerciseId);
    }

    private void SelectLog(FoodLog log)
    {
        selectedLog = log;
    }

    private async Task HandleValidSubmit()
    {

    }

    private async Task ClearOrDelete()
    {
        selectedLog = new FoodLog();
        StateHasChanged();
    }

    private void IncrementWeight()
    {
        int weightIncrement = 5;//might want to add this to appsettings
        selectedLog.GramsConsumed += weightIncrement;
    }

    private void DecrementWeight()
    {
        int weightIncrement = 5;//might want to add this to appsettings
        if (selectedLog.GramsConsumed > weightIncrement)
        {
            selectedLog.GramsConsumed -= weightIncrement;
        }
    }
}