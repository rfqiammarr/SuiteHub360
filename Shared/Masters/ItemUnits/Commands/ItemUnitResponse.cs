using RifqiAmmarR.SuiteHub360.Shared.Common.Responses;

namespace RifqiAmmarR.SuiteHub360.Shared.Masters.ItemUnits.Commands;

public class ItemUnitResponse : Response
{
    public int ItemUnitId { get; set; }
    public string ItemUnitName { get; set; } = default!;
}
