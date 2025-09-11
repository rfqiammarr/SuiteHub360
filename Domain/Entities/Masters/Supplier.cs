using RifqiAmmarR.SuiteHub360.Domain.Abstracts;
using RifqiAmmarR.SuiteHub360.Domain.Entities.Transactions.Inventories;

namespace RifqiAmmarR.SuiteHub360.Domain.Entities.Masters;

public class Supplier : ModifiedEntity
{
    public int SupplierID { get; set; }
    public string SupplierName { get; set; } = default!;
    public string Phone { get; set; } = default!;
    public string Email { get; set; } = default!;
    public string Address { get; set; } = default!;

    public ICollection<InventoryItem> InventoryItems { get; set; } = default!;
    public ICollection<ItemReceiving> ItemReceivings { get; set; } = default!;
}
