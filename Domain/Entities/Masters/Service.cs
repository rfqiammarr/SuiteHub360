using RifqiAmmarR.SuiteHub360.Domain.Abstracts;
using RifqiAmmarR.SuiteHub360.Domain.Entities.Transactions.Bookings;

namespace RifqiAmmarR.SuiteHub360.Domain.Entities.Masters;

public class Service : ModifiedEntity
{
    public int ServiceID { get; set; }
    public string Name { get; set; } = default!;
    public string Description { get; set; } = default!;
    public decimal Price { get; set; }

    public ICollection<BookingService> BookingServices { get; set; } = default!;
}
