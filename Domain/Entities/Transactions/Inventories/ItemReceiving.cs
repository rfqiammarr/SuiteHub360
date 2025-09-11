using RifqiAmmarR.SuiteHub360.Domain.Abstracts;
using RifqiAmmarR.SuiteHub360.Domain.Entities.Transactions.Users;
using RifqiAmmarR.SuiteHub360.Domain.Entities.Masters;

namespace RifqiAmmarR.SuiteHub360.Domain.Entities.Transactions.Inventories;

public class ItemReceiving : ModifiedEntity
{
    public Guid ReceiveID { get; set; }
    public Guid ItemID { get; set; }
    public int QuantityReceived { get; set; }
    public int SupplierID { get; set; }
    public Guid ReceivedBy { get; set; }
    public DateTime ReceiveDate { get; set; }

    public InventoryItem InventoryItem { get; set; } = default!;
    public Supplier Suppliers { get; set; } = default!;
    public User ReceivedByUsers { get; set; } = default!;
}
