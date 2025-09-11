using RifqiAmmarR.SuiteHub360.Shared.Common.Responses;

namespace RifqiAmmarR.SuiteHub360.Shared.Masters.Roles.Commands;

public class RoleResponse : Response
{
    public int RoleId { get; set; }
    public string RoleName { get; set; } = default!;
}
