using JwtProject.Model;

namespace JwtProject.Queries;

public class OrderQuery
{
    public OrderStatus status { get; set; }
    public OrderDeliveryType deliveryType { get; set; }
    public string address { get; set; }
    public int[] ids_products { get; set; }
}