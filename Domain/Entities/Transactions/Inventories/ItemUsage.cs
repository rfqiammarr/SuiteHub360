using RifqiAmmarR.SuiteHub360.Domain.Abstracts;
using RifqiAmmarR.SuiteHub360.Domain.Entities.Transactions.Users;
using RifqiAmmarR.SuiteHub360.Domain.Entities.Masters;

namespace RifqiAmmarR.SuiteHub360.Domain.Entities.Transactions.Inventories;

public class ItemUsage : ModifiedEntity
{
    public Guid UsageID { get; set; }
    public Guid ItemID { get; set; }
    public Guid UsedBy { get; set; }
    public int RoomID { get; set; }
    public int QuantityUsed { get; set; }
    public DateTime UsageDate { get; set; }
    public string Notes { get; set; } = default!;

    public InventoryItem InventoryItem { get; set; } = default!;
    public User UsedByUsers { get; set; } = default!;
    public Room Rooms { get; set; } = default!;
}
