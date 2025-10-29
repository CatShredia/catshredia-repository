namespace JwtProject.Queries;

public class ProductQuery
{
    public string name { get; set; }
    public string description { get; set; }
    public int price { get; set; }
    public string stroke { get; set; }
    public bool is_active { get; set; }
    
    public int id_category { get; set; }
}