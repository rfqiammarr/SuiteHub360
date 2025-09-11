using RifqiAmmarR.SuiteHub360.Shared.Common.Responses;

namespace RifqiAmmarR.SuiteHub360.Shared.Masters.Roles.Queries;

public class GetRoleResponse : Response
{
    public int RoleId { get; set; }
    public string RoleName { get; set; } = default!;
}
