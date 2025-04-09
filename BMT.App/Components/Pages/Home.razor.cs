using BMT.App.Services;
using BMT.Data.Models;
using Microsoft.AspNetCore.Components;

namespace BMT.App.Components.Pages;

public partial class Home : ComponentBase
{
    [Inject]
    private DataService _dataService { get; set; }

    private List<FoodLog> logs = [];

    protected override async Task OnInitializedAsync()
    {
        logs = await _dataService.GetLogsForSelectedDate();
    }

    private string DisplayDateText
    {
        get
        {
            var today = DateTime.Today;
            var date = _dataService.SelectedDate.Date;

            if (date == today)
            {
                return "Today";
            }
            else if (date == today.AddDays(-1))
            {
                return "Yesterday";
            }
            else if (date == today.AddDays(1))
            {
                return "Tomorrow";
            }
            else
            {
                return date.ToString("ddd, MMM dd");
            }
        }
    }

    private async Task SetDateToToday()
    {
        _dataService.SelectedDate = DateTime.Now;
        logs = await _dataService.GetLogsForSelectedDate();
    }

    private async Task GoToPreviousDay()
    {
        _dataService.SelectedDate = _dataService.SelectedDate.AddDays(-1);
        logs = await _dataService.GetLogsForSelectedDate();
    }

    private async Task GoToNextDay()
    {
        _dataService.SelectedDate = _dataService.SelectedDate.AddDays(1);
        logs = await _dataService.GetLogsForSelectedDate();
    }
}