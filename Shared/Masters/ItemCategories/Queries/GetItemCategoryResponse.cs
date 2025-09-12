using RifqiAmmarR.SuiteHub360.Shared.Common.Responses;

namespace RifqiAmmarR.SuiteHub360.Shared.Masters.ItemCategories.Queries;

public class GetItemCategoryResponse : Response
{
    public int CategoryID { get; set; }
    public string Name { get; set; } = default!;
}
