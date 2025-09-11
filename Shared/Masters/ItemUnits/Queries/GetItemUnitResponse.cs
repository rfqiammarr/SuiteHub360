using RifqiAmmarR.SuiteHub360.Shared.Common.Responses;

namespace RifqiAmmarR.SuiteHub360.Shared.Masters.ItemUnits.Queries;

public class GetItemUnitResponse : Response
{
    public int ItemUnitId { get; set; }
    public string ItemUnitName { get; set; } = default!;
}
