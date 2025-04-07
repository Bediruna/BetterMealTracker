using SQLite;

namespace BMT.Data.Models;

public abstract class BaseModel
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }
}