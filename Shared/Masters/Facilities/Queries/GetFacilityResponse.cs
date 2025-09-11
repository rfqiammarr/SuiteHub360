using RifqiAmmarR.SuiteHub360.Shared.Common.Responses;

namespace RifqiAmmarR.SuiteHub360.Shared.Masters.Facilities.Queries;

public class GetFacilityResponse : Response
{
    public int FacilityId { get; set; }
    public string FacilityName { get; set; } = default!;
}
