using SQLite;

public class OffDetails
{
    // Basic info
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }
    public string OffId { get; set; }
    public string ProductName { get; set; }
    public string Brands { get; set; }
    public string Ingredients { get; set; }

    // Nutriments
    public double? Calories { get; set; }
    public double? Protein { get; set; }
    public double? Fat { get; set; }
    public double? SaturatedFat { get; set; }
    public double? TransFatG { get; set; }
    public double? CarbsG { get; set; }
    public double? FiberG { get; set; }
    public double? SugarG { get; set; }
    public double? AddedSugarG { get; set; }

    public double? CholesterolMg { get; set; }
    public double? SodiumMg { get; set; }
    public double? PotassiumMg { get; set; }
    public double? CalciumMg { get; set; }
    public double? IronMg { get; set; }
    public double? MagnesiumMg { get; set; }
    public double? ZincMg { get; set; }

    public double? VitaminAug { get; set; }
    public double? VitaminCMg { get; set; }
    public double? VitaminDug { get; set; }
    public double? VitaminB12ug { get; set; }

    // Serving info
    public string Quantity { get; set; }
    public double? ProductQuantity { get; set; }
    public string ProductQuantityUnit { get; set; }
    public string ServingSize { get; set; }
    public double? ServingQuantity { get; set; }
    public string ServingQuantityUnit { get; set; }

    // Creation date
    public DateTime CreateDate { get; set; }

    public OffDetails()
    {
        CreateDate = DateTime.Now;
    }
}
