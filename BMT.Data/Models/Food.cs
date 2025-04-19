namespace BMT.Data.Models;

public class Food : BaseModel
{
    public string ProductName { get; set; }
    public double Calories { get; set; }
    public double Protein { get; set; }
    public double Fat { get; set; }
    public double Carbs { get; set; }
    public double Sugar { get; set; }
    public string ServingSize { get; set; }
    public long LastUsedDate { get; set; }
}
