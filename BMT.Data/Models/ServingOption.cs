namespace BMT.Data.Models;

public class ServingOption : BaseModel
{
    public int FoodId { get; set; }
    public Food Food { get; set; } = null!;

    public float SizeG { get; set; }

    public string Description { get; set; }
    public bool IsDefault { get; set; } = false;
}
