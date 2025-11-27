namespace Marketplace.Core.Entities;

public class Category
{
    public long Id { get; set; }
    public string Name { get; set; } 
    public ICollection<Product> Products { get; } = new List<Product>();
}