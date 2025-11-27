namespace Marketplace.Core.Entities;

public class InventoryTransaction
{
    public long Id { get; set; }
    public long InventoryId { get; set; }
    public Inventory Inventory { get; set; } 
    public TxnType TxnType { get; set; }
    public int Quantity { get; set; }
    public Guid? BatchId { get; set; }
    public decimal? CostPerUnit { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}