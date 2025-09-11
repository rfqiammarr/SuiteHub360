using System.ComponentModel.DataAnnotations;

namespace RifqiAmmarR.SuiteHub360.Shared.Masters.ItemCategories.Commands;
public class ItemCategoryRequest
{
    [Required]
    [StringLength(15)]
    public string ItemCategoryName { get; set; } = default!;
}
