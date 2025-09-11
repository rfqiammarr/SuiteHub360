using System.ComponentModel.DataAnnotations;

namespace RifqiAmmarR.SuiteHub360.Shared.Transactions.Bookings.Commands;
public class BookingRequest
{
    [Required]
    public Guid BookingID { get; set; }
    [Required]
    public string BookingName { get; set; } = default!;
    [Required]
    public Guid GuestID { get; set; }
    [Required]
    public int RoomID { get; set; }
    [Required]
    public DateTime CheckInDate { get; set; }
    [Required]
    public DateTime CheckOutDate { get; set; }
    public string BookingStatus { get; set; } = default!;
    public decimal TotalAmount { get; set; }
}
