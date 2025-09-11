using RifqiAmmarR.SuiteHub360.Shared.Common.Responses;

namespace RifqiAmmarR.SuiteHub360.Shared.Masters.Facilities.Commands;

public class FacilityResponse : Response
{
    public int FacilityId { get; set; }
    public string FacilityName { get; set; } = default!;
}
