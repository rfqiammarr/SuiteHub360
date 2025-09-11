using RifqiAmmarR.SuiteHub360.Domain.Abstracts;
using RifqiAmmarR.SuiteHub360.Domain.Entities.Transactions.Services;

namespace RifqiAmmarR.SuiteHub360.Domain.Entities.Masters;

public class Facility : ModifiedEntity
{
    public int FacilityId { get; set; }
    public string FacilitiesName { get; set; } = default!;

    public ICollection<RoomFacility> RoomFacilities { get; set; } = default!;
}
