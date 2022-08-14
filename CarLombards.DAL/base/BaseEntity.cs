namespace CarLombards.DAL;

public class BaseEntity : IEntity
{
    public long Id { get; set; }
    public string? Title { get; set; }
    public bool IsActive { get; set; }
    public DateTime CreateDate { get; set; }
    public DateTime? ModifyDate { get; set; }

    public BaseEntity()
    {
        IsActive = true;
        CreateDate = DateTime.UtcNow;
        ModifyDate = DateTime.UtcNow;
    }
}