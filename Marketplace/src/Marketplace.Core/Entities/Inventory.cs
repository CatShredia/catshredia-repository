namespace Marketplace.Core.Entities;

public class Inventory
{
    public long Id { get; set; }
    public long ProductId { get; set; }
    public Product Product { get; set; } 
    public long WarehouseId { get; set; }
    public Warehouse Warehouse { get; set; } 
    public int Quantity { get; set; }
    public int Reserved { get; set; }

    public ICollection<InventoryTransaction> Transactions { get; } = new List<InventoryTransaction>();
}