using System.ComponentModel.DataAnnotations;

namespace RifqiAmmarR.SuiteHub360.Shared.Masters.Suppliers.Commands;
public class SupplierRequest
{
    [Required]
    [StringLength(15)]
    public string SupplierName { get; set; } = default!;
}
