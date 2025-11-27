namespace Marketplace.Core.Entities;

public class Street
{
    public long Id { get; set; }
    public string Name { get; set; } 
    public long CityId { get; set; }
    public City City { get; set; } 
    public ICollection<Address> Addresses { get; } = new List<Address>();
}