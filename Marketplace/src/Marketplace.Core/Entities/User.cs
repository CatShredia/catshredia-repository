namespace Marketplace.Core.Entities;

public class User
{
    public long Id { get; set; }
    public string Login { get; set; } 
    public string Password { get; set; } 
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime EditedAt { get; set; } = DateTime.UtcNow;
    public Seller? Seller { get; set; } // One-to-zero-or-one
}