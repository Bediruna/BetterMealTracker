using BMT.App.Services;
using BMT.Data.Models;
using Microsoft.AspNetCore.Components;

namespace BMT.App.Components.Pages;
public partial class AddFoodPage : ComponentBase
{
    [Inject]
    private DataService dataService { get; set; }

    [Inject]
    private NavigationManager NavigationManager { get; set; }

    private string errorMessage;

    private Food NewFood { get; set; } = new Food();

    private async Task HandleValidSubmit()
    {
        try
        {
            await dataService.db.InsertAsync(NewFood);
            errorMessage = ""; // Clear the error message upon successful submission
        }
        catch (Exception ex)
        {
            errorMessage = ex.Message; // Set the error message if an exception occurs
        }
    }

}
