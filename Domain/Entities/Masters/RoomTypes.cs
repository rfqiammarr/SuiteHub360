using RifqiAmmarR.SuiteHub360.Domain.Abstracts;

namespace RifqiAmmarR.SuiteHub360.Domain.Entities.Masters;

public class RoomTypes : ModifiedEntity
{
    public int RoomTypeID { get; set; }
    public string Name { get; set; } = default!;
    public string Description { get; set; } = default!;
    public int Capacity { get; set; }
    public decimal BasePrice { get; set; }

    public ICollection<Room> Rooms { get; set; } = default!;
}
