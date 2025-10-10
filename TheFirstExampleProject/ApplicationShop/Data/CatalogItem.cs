namespace ApplicationShop.Data;

public class CatalogItem
{
    public int ProductId { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public string Provider { get; set; }
    public int BasketCount { get; set; }
}