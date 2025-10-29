using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JwtProject.Model;

public class Order
{
    [Key]
    public int id_order { get; set; }
    public OrderStatus status { get; set; }
    public OrderDeliveryType deliveryType { get; set; }
    public string address { get; set; }
    
    // relation to 'user' table
    [Required] [ForeignKey("User")] 
    public int id_user { get; set; }
    public User User { get; set; }
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