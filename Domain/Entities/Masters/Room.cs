using RifqiAmmarR.SuiteHub360.Domain.Abstracts;
using RifqiAmmarR.SuiteHub360.Domain.Entities.Transactions.Bookings;
using RifqiAmmarR.SuiteHub360.Domain.Entities.Transactions.Inventories;
using RifqiAmmarR.SuiteHub360.Domain.Entities.Transactions.Services;

namespace RifqiAmmarR.SuiteHub360.Domain.Entities.Masters;

public class Room : ModifiedEntity
{
    public int RoomID { get; set; }
    public string RoomName { get; set; } = default!;    
    public string RoomNumber { get; set; } = default!;
    public int RoomTypeID { get; set; }
    public int Floor { get; set; }
    public string Status { get; set; } = default!;
    public decimal PricePerNight { get; set; }
    public string Description { get; set; } = default!;
    public DateTime UpdatedAt { get; set; }
    public bool IsBooking { get; set; } = false;

    public RoomType RoomType { get; set; } = default!;
    public ICollection<RoomFacility> FacilityRooms { get; set; } = default!;
    public ICollection<Booking> Bookings { get; set; } = default!;
    public ICollection<ItemUsage> ItemUsages { get; set; } = default!;
}
