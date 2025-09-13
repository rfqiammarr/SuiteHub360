using RifqiAmmarR.SuiteHub360.Shared.Common.Responses;
using System.ComponentModel.DataAnnotations;

namespace RifqiAmmarR.SuiteHub360.Shared.Masters.Rooms.Queries;

public class GetRoomResponse : Response
{
    public int RoomId { get; set; }
    public string RoomName { get; set; } = default!;
    public string RoomNumber { get; set; } = default!;
    public int RoomTypeID { get; set; }
    public string RoomTypeName { get; set; } = default!;
    public int Floor { get; set; }
    public string Status { get; set; } = default!;
    public decimal PricePerNight { get; set; }
    public string Description { get; set; } = default!;
    public DateTime UpdatedAt { get; set; }
    public bool IsBooking { get; set; } = false;
}
