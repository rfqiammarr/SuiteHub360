using RifqiAmmarR.SuiteHub360.Domain.Abstracts;
using RifqiAmmarR.SuiteHub360.Domain.Entities.Masters;

namespace RifqiAmmarR.SuiteHub360.Domain.Entities.Transactions.Inventories;

public class InventoryItem : ModifiedEntity
{
    public Guid ItemID { get; set; }
    public string ItemName { get; set; } = default!;
    public int CategoryID { get; set; }
    public int UnitID { get; set; }
    public int ReorderLevel { get; set; }
    public int SupplierID { get; set; }
    public bool IsActive { get; set; }

    public ItemCategory Categorys { get; set; } = default!;
    public ItemUnit Units { get; set; } = default!;
    public Supplier Suppliers { get; set; } = default!;
    public ICollection<Stock> Stocks { get; set; } = default!;
    public ICollection<ItemUsage> ItemUsages { get; set; } = default!;
    public ICollection<ItemReceiving> ItemReceivings { get; set; } = default!;
}
