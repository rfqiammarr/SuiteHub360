using RifqiAmmarR.SuiteHub360.Shared.Common.Responses;

namespace RifqiAmmarR.SuiteHub360.Shared.Masters.ItemCategories.Commands;

public class ItemCategoryResponse : Response
{
    public int ItemCategoryId { get; set; }
    public string ItemCategoryName { get; set; } = default!;
}
