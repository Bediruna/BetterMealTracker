namespace BMT.Data.Models;

public class Food : BaseModel
{
    public string Name { get; set; }
    public string Brand { get; set; }
    public double Calories { get; set; }
    public double ProteinG { get; set; }
    public double FatG { get; set; }
    public double SaturatedFatG { get; set; }
    public double TransFatG { get; set; }
    public double CarbsG { get; set; }
    public double FiberG { get; set; }
    public double SugarG { get; set; }
    public double AddedSugarG { get; set; }
    public double CholesterolMg { get; set; }
    public double SodiumMg { get; set; }
    public double PotassiumMg { get; set; }
    public double CalciumMg { get; set; }
    public double IronMg { get; set; }
    public double VitaminAug { get; set; }
    public double VitaminCMg { get; set; }
    public double VitaminDug { get; set; }
    public double VitaminB12ug { get; set; }
    public double MagnesiumMg { get; set; }
    public double ZincMg { get; set; }
}
