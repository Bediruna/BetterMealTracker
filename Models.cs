public abstract class BaseModel
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }
    public long CreatedAt { get; set; }
}
public class ErrorLog : BaseModel
{
    public string ErrorMessage { get; set; }
}

// Preload with default values: 100 most commonly consumed foods
public class Food : BaseModel
{
    public string Brand { get; set; }//optional
    public string Name { get; set; }

    public double Calories { get; set; }
    public double Protein { get; set; }
    public double Fat { get; set; }
    public double CholesterolMg { get; set; }
    public double SodiumMg { get; set; }
    public double Carbs { get; set; }
    public double Sugar { get; set; }
    public double Fiber { get; set; }

    public string ServingDescription { get; set; }
    public float ServingMassG { get; set; }
    public float ServingVolumeMl { get; set; }

    public long LastUsedAt { get; set; }
}

public class MealType : BaseModel
{
    public string Name { get; set; } // e.g. Breakfast, Lunch, Dinner, Sahoor, Iftar, Uncategorized
}

public class FoodLog : BaseModel
{
    public int FoodId { get; set; }

    public float MassConsumedG { get; set; }
    public float ServingsConsumed { get; set; }

    public int? MealTypeId { get; set; }

    public long ConsumedAt { get; set; } = DateTime.Now;//can be different from CreatedAt, raises the question of whether or not we should even store CreatedAt

    public string? Notes { get; set; }
}

public class Settings
{
    public bool ShowNavbarOnBottom { get; set; } = true;
}
