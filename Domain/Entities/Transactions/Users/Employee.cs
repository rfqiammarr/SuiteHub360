using RifqiAmmarR.SuiteHub360.Domain.Abstracts;

namespace RifqiAmmarR.SuiteHub360.Domain.Entities.Transactions.Users;

public class Employee : ModifiedEntity
{
    public Guid EmployeeId { get; set; }
    public string FullName { get; set; } = default!;
    public string Email { get; set; } = default!;
    public string PhoneNumber { get; set; } = default!;
    public string Address { get; set; } = default!;

    public Guid UserId { get; set; }
    public User Users { get; set; } = default!;
}
