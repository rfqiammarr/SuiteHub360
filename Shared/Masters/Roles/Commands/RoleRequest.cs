using System.ComponentModel.DataAnnotations;

namespace RifqiAmmarR.SuiteHub360.Shared.Masters.Roles.Commands;
public class RoleRequest
{
    [Required]
    [StringLength(15)]
    public string RoleName { get; set; } = default!;
}
