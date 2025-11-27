namespace Marketplace.Core.Entities;

public class Country
{
    public long Id { get; set; }
    public string Name { get; set; } 
    
    public ICollection<City> Cities { get; } = new List<City>();
}