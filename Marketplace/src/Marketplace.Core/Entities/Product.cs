namespace Marketplace.Core.Entities;

public class Product
{
    public long Id { get; set; }
    public string Sku { get; set; } 
    public string Title { get; set; } 
    public string Description { get; set; } 
    public long SellerId { get; set; }
    public Seller Seller { get; set; } 
    public long CategoryId { get; set; }
    public Category Category { get; set; } 
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime EditedAt { get; set; } = DateTime.UtcNow;

    public ICollection<ProductTag> ProductTags { get; } = new List<ProductTag>();
    public ICollection<Inventory> InventoryItems { get; } = new List<Inventory>();
}