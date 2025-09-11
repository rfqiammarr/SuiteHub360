using RifqiAmmarR.SuiteHub360.Domain.Abstracts;
using RifqiAmmarR.SuiteHub360.Domain.Entities.Masters;

namespace RifqiAmmarR.SuiteHub360.Domain.Entities.Transactions.Bookings;

public class BookingService : ModifiedEntity
{
    public Guid BookingServiceID { get; set; }
    public Guid BookingID { get; set; }
    public int ServiceID { get; set; }
    public int Quantity { get; set; }
    public decimal Total { get; set; }

    public Booking Booking { get; set; } = default!;
    public Service Services { get; set; } = default!;
}
