using System.ComponentModel.DataAnnotations;

namespace JwtProject.Model;

public class Order
{
    [Key]
    public int id_order { get; set; }
    public OrderStatus status { get; set; }
    public OrderDeliveryType deliveryType { get; set; }
    public string address { get; set; }
}

public enum OrderStatus
{
    preparing,
    delivering,
    delivered,
    canceled
}

public enum OrderDeliveryType
{
    car,
    helicopter,
    walkerman,
    deathstar
}