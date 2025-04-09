namespace BMT.Data.Models;

public class FoodLog : BaseModel
{
    public int? FoodId { get; set; }
    public Food? Food { get; set; }

    public float GramsConsumed { get; set; }
    public float? ServingsConsumed { get; set; }

    public int MealTypeId { get; set; }

    public DateTime DateConsumed { get; set; } = DateTime.Now;
    public string? Notes { get; set; }
}
