using RifqiAmmarR.SuiteHub360.Domain.Abstracts;
using RifqiAmmarR.SuiteHub360.Domain.Entities.Transactions.Bookings;

namespace RifqiAmmarR.SuiteHub360.Domain.Entities.Transactions.Users;
public class Guest : ModifiedEntity
{
    public Guid GuestID { get; set; }
    public string FullName { get; set; } = default!;
    public string Email { get; set; } = default!;
    public string PhoneNumber { get; set; } = default!;
    public string Address { get; set; } = default!;

    public Guid UserId { get; set; }
    public User Users { get; set; } = default!;

    public ICollection<Booking> Bookings { get; set; } = new List<Booking>();
}
