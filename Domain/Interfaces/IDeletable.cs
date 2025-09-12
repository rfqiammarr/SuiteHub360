namespace RifqiAmmarR.SuiteHub360.Domain.Interfaces;

public interface IDeletable
{
    public bool IsDeleted { get; set; }
    public DateTime? DeletedAt { get; set; }
    public string? DeletedBy { get; set; }
}
