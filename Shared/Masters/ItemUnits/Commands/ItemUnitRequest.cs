using System.ComponentModel.DataAnnotations;

namespace RifqiAmmarR.SuiteHub360.Shared.Masters.ItemUnits.Commands;
public class ItemUnitRequest
{
    [Required]
    [StringLength(15)]
    public string ItemUnitName { get; set; } = default!;
}
