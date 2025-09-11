using RifqiAmmarR.SuiteHub360.Domain.Abstracts;
using RifqiAmmarR.SuiteHub360.Domain.Entities.Transactions.Inventories;
using RifqiAmmarR.SuiteHub360.Domain.Entities.Masters;

namespace RifqiAmmarR.SuiteHub360.Domain.Entities.Transactions.Users;
public class User : ModifiedEntity
{
    public Guid UserID { get; set; }
    public string Username { get; set; } = default!;
    public string Email { get; set; } = default!;
    public string PasswordHash { get; set; } = default!;
    public bool IsActive { get; set; }
    public DateTime LastLogin { get; set; }

    public int RoleId { get; set; }
    public Role Role { get; set; } = default!;
    public ICollection<Guest> Guests { get; set; } = default!;
    public ICollection<Employee> Employees { get; set; } = default!;
    public ICollection<ItemUsage> ItemUsages { get; set; } = default!;
    public ICollection<ItemReceiving> ItemReceivings { get; set; } = default!;
}
