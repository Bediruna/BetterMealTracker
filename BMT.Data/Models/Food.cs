namespace BMT.Data.Models;

public class Food : BaseModel
{
    public required string Name { get; set; }
    public string? Brand { get; set; }
    public float? Calories { get; set; }
    public float? ProteinG { get; set; }
    public float? FatG { get; set; }
    public float? SaturatedFatG { get; set; }
    public float? TransFatG { get; set; }
    public float? CarbsG { get; set; }
    public float? FiberG { get; set; }
    public float? SugarG { get; set; }
    public float? AddedSugarG { get; set; }
    public float? CholesterolMg { get; set; }
    public float? SodiumMg { get; set; }
    public float? PotassiumMg { get; set; }
    public float? CalciumMg { get; set; }
    public float? IronMg { get; set; }
    public float? VitaminAµg { get; set; }
    public float? VitaminCMg { get; set; }
    public float? VitaminDµg { get; set; }
    public float? VitaminB12µg { get; set; }
    public float? MagnesiumMg { get; set; }
    public float? ZincMg { get; set; }

    //public ICollection<ServingOption> ServingOptions { get; set; } = new List<ServingOption>();
    //public ICollection<FoodLog> FoodLogs { get; set; } = new List<FoodLog>();
}
