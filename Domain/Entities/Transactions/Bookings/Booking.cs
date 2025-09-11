using RifqiAmmarR.SuiteHub360.Domain.Abstracts;
using RifqiAmmarR.SuiteHub360.Domain.Entities.Transactions.Payments;
using RifqiAmmarR.SuiteHub360.Domain.Entities.Transactions.Users;
using RifqiAmmarR.SuiteHub360.Domain.Entities.Masters;

namespace RifqiAmmarR.SuiteHub360.Domain.Entities.Transactions.Bookings;

public class Booking : ModifiedEntity
{
    public Guid BookingID { get; set; }
    public Guid GuestID { get; set; }
    public int RoomID { get; set; }
    public DateTime CheckInDate { get; set; }
    public DateTime CheckOutDate { get; set; }
    public string BookingStatus { get; set; } = default!;
    public decimal TotalAmount { get; set; }

    public Guest Guests { get; set; } = default!;
    public Room Rooms { get; set; } = default!;
    public ICollection<Payment> Payments { get; set; } = default!;
    public ICollection<BookingService> BookingServices { get; set; } = default!;
}
