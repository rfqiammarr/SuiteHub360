using System.ComponentModel.DataAnnotations;

namespace RifqiAmmarR.SuiteHub360.Shared.Masters.Suppliers.Commands;
public class SupplierRequest
{
    public int? SupplierId { get; set; }
    [Required]
    [StringLength(15)]
    public string SupplierName { get; set; } = default!;
    public string Phone { get; set; } = default!;
    public string Email { get; set; } = default!;
    public string Address { get; set; } = default!;
}
