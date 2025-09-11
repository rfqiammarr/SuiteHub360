using RifqiAmmarR.SuiteHub360.Domain.Abstracts;
using RifqiAmmarR.SuiteHub360.Domain.Entities.Transactions.Bookings;

namespace RifqiAmmarR.SuiteHub360.Domain.Entities.Transactions.Payments;

public class Payment : ModifiedEntity
{
    public Guid PaymentID { get; set; }
    public decimal AmountPaid { get; set; }
    public DateTime PaymentDate { get; set; }
    public string PaymentMethod { get; set; } = default!;
    public string PaymentStatus { get; set; } = default!;

    public Guid BookingID { get; set; }
    public Booking Booking { get; set; } = default!;
}
