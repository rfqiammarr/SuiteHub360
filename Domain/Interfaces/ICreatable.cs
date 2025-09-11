namespace RifqiAmmarR.SuiteHub360.Domain.Interfaces;

public interface ICreatable
{
    public DateTimeOffset CreatedAt { get; set; }
    public string CreatedBy { get; set; }
}
