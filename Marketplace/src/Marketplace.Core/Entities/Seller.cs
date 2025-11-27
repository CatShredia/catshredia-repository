namespace Marketplace.Core.Entities;

public class Seller
{
    public long Id { get; set; }
    public long UserId { get; set; }
    public User User { get; set; } 
    public ICollection<Product> Products { get; } = new List<Product>();
}