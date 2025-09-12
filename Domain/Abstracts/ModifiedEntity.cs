using RifqiAmmarR.SuiteHub360.Domain.Interfaces;

namespace RifqiAmmarR.SuiteHub360.Domain.Abstracts;

public abstract class ModifiedEntity : Entity, IDeletable, IUpdatable
{
    public DateTimeOffset? Modified { get; set; }
    public string? ModifiedBy { get; set; }
    public bool IsDeleted { get; set; } = false;
    public DateTime? DeletedAt { get; set; }
    public string? DeletedBy { get; set; }
}
