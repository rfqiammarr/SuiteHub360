using RifqiAmmarR.SuiteHub360.Domain.Abstracts;
using RifqiAmmarR.SuiteHub360.Domain.Entities.Masters;

namespace RifqiAmmarR.SuiteHub360.Domain.Entities.Transactions.Services;

public class RoomFacility : ModifiedEntity
{
    public Guid FacilityRoomsId { get; set; }
    public int FacilityId { get; set; }
    public int RoomID { get; set; }

    public Facility Facility { get; set; } = default!;
    public Room Room { get; set; } = default!;
}
