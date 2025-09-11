using System.ComponentModel.DataAnnotations;

namespace RifqiAmmarR.SuiteHub360.Shared.Masters.Facilities.Commands;
public class FacilityRequest
{
    [Required]
    [StringLength(15)]
    public string FacilityName { get; set; } = default!;
}
