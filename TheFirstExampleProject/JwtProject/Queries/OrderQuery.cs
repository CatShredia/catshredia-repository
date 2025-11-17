using JwtProject.Model;

namespace JwtProject.Queries;

public class OrderQuery
{
    public int id_status { get; set; }
    public int id_delivery_type { get; set; }
    
    public string address { get; set; }
    public int[] ids_products { get; set; }
}