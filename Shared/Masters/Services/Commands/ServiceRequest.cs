using System.ComponentModel.DataAnnotations;

namespace RifqiAmmarR.SuiteHub360.Shared.Masters.Services.Commands;
public class ServiceRequest
{
    [Required]
    [StringLength(15)]
    public string ServiceName { get; set; } = default!;
}
