using BMT.App.Services;
using BMT.Data.Models;
using Microsoft.AspNetCore.Components;

namespace BMT.App.Components.Pages;
public partial class FoodLogPage : ComponentBase
{
    [Inject]
    private DataService dataService { get; set; }

    private string SearchQuery { get; set; } = string.Empty;
    private List<Food> SearchResults { get; set; } = new();
    private string errorMessage;

    private async Task PerformSearch()
    {
        try
        {
            if (!string.IsNullOrWhiteSpace(SearchQuery))
            {
                SearchResults = await dataService.SearchFoods(SearchQuery);
            }
            else
            {
                SearchResults.Clear();
            }
        }
        catch (Exception ex)
        {
            errorMessage = $"An error occurred while searching: {ex.Message}";
        }
    }
}
