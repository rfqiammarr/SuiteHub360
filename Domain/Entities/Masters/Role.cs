using RifqiAmmarR.SuiteHub360.Domain.Abstracts;
using RifqiAmmarR.SuiteHub360.Domain.Entities.Transactions.Users;

namespace RifqiAmmarR.SuiteHub360.Domain.Entities.Masters;

public class Role : ModifiedEntity
{
    public int RoleId { get; set; }
    public string RoleName { get; set; } = default!;

    public ICollection<User> Users { get; set; } = default!;
}
