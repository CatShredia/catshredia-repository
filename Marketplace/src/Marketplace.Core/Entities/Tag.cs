namespace Marketplace.Core.Entities;

public class Tag
{
    public long Id { get; set; }
    public string Name { get; set; } 
    public ICollection<ProductTag> ProductTags { get; } = new List<ProductTag>();
}