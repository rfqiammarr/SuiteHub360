using RifqiAmmarR.SuiteHub360.Domain.Interfaces;

namespace RifqiAmmarR.SuiteHub360.Domain.Abstracts;

public abstract class ModifiedEntity : Entity, IDeletable, IUpdatable
{
    public bool IsDeleted { get; set; } = false;
    public DateTimeOffset? Modified { get; set; }
    public string? ModifiedBy { get; set; }
}
