namespace RifqiAmmarR.SuiteHub360.Domain.Interfaces;

public interface IUpdatable
{
    public DateTimeOffset? Modified { get; set; }
    public string? ModifiedBy { get; set; }
}
