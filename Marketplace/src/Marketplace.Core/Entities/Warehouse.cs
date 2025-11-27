namespace Marketplace.Core.Entities;

public class Warehouse
{
    public long Id { get; set; }
    public string Name { get; set; } 
    public long AddressId { get; set; }
    public Address Address { get; set; } 
    public ICollection<Inventory> InventoryItems { get; } = new List<Inventory>();
}