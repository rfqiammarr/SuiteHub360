using RifqiAmmarR.SuiteHub360.Shared.Common.Responses;

namespace RifqiAmmarR.SuiteHub360.Shared.Transactions.Bookings.Queries;

public class GetBookingResponse : Response
{
    public Guid BookingID { get; set; }
    public string BookingName { get; set; } = default!;
    public Guid GuestID { get; set; }
    public string GuestName { get; set; } = string.Empty;
    public int RoomID { get; set; }
    public int RoomName { get; set; }
    public DateTime CheckInDate { get; set; }
    public DateTime CheckOutDate { get; set; }
    public string BookingStatus { get; set; } = default!;
    public decimal TotalAmount { get; set; }
}
