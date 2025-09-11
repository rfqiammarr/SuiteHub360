using RifqiAmmarR.SuiteHub360.Domain.Abstracts;
using RifqiAmmarR.SuiteHub360.Domain.Entities.Transactions.Inventories;

namespace RifqiAmmarR.SuiteHub360.Domain.Entities.Masters;

public class ItemCategory : ModifiedEntity
{
    public int CategoryID { get; set; }
    public string Name { get; set; } = default!;

    public ICollection<InventoryItem> InventoryItems { get; set; } = default!;
}
