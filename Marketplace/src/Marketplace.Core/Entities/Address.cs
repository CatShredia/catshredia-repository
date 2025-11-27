namespace Marketplace.Core.Entities;

public class Address
{
    public long Id { get; set; }
    public string HouseNumber { get; set; } 
    public string? Corpus { get; set; }
    public string? Apartment { get; set; }
    public long StreetId { get; set; }
    public Street Street { get; set; } 
    public ICollection<Warehouse> Warehouses { get; } = new List<Warehouse>();
}