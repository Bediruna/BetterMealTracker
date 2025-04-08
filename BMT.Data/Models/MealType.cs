namespace BMT.Data.Models;

public class MealType : BaseModel
{
    public required string Name { get; set; }

    //public ICollection<FoodLog> FoodLogs { get; set; } = new List<FoodLog>();
}
