using BMT.App.Services;
using Microsoft.AspNetCore.Components;

namespace BMT.App.Components.Pages;
public partial class FoodLogPage : ComponentBase
{

    [Inject]
    private DataService dataService { get; set; }

    [Parameter]
    public int ExerciseId { get; set; }

    private string errorMessage;

    protected override async Task OnInitializedAsync()
    {

    }

    private async Task HandleValidSubmit()
    {

    }
}