using RifqiAmmarR.SuiteHub360.Shared.Common.Responses;

namespace RifqiAmmarR.SuiteHub360.Shared.Masters.Services.Commands;

public class ServiceResponse : Response
{
    public int ServiceId { get; set; }
    public string ServiceName { get; set; } = default!;
}
