using System.ComponentModel.DataAnnotations;

namespace RifqiAmmarR.SuiteHub360.Shared.Masters.Services.Commands;
public class ServiceRequest
{
    public int ServiceId { get; set; }
    [Required]
    [StringLength(50)]
    public string ServiceName { get; set; } = default!;
    public string Description { get; set; } = default!;
    public decimal Price { get; set; }
}
