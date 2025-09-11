using RifqiAmmarR.SuiteHub360.Domain.Abstracts;

namespace RifqiAmmarR.SuiteHub360.Domain.Entities.Transactions.Inventories;

public class Stock : ModifiedEntity
{
    public Guid StockID { get; set; }
    public Guid ItemID { get; set; }
    public string Location { get; set; } = default!;
    public int Quantity { get; set; }
    public DateTime LastUpdated { get; set; }

    public InventoryItem InventoryItem { get; set; } = default!;
}
