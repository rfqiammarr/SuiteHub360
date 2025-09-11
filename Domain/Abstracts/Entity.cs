using RifqiAmmarR.SuiteHub360.Domain.Interfaces;

namespace RifqiAmmarR.SuiteHub360.Domain.Abstracts;

public abstract class Entity : ICreatable
{
    public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.Now;
    public string CreatedBy { get; set; } = default!;
}
