namespace Marketplace.Core.Entities;

public class City
{
    public long Id { get; set; }
    public string Name { get; set; }
    public long CountryId { get; set; }
    public Country Country { get; set; }

    // relation to 'city' table
    public ICollection<Street> Streets { get; } = new List<Street>();
}