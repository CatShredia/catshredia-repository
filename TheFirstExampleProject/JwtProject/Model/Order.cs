using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JwtProject.Model;

public class Order
{
    [Key]
    public int id_order { get; set; }
    public string address { get; set; }
    
    // relation to 'user' table
    [Required] [ForeignKey("User")] 
    public int id_user { get; set; }
    public User User { get; set; }
    
    // relation to 'order_status' table
    [Required] [ForeignKey("OrderStatus")] 
    public int id_status { get; set; }
    public OrderStatus OrderStatus { get; set; }
    
    // relation to 'order_delivery_type' table
    [Required] [ForeignKey("OrderDeliveryType")] 
    public int id_delivery_type { get; set; }
    public OrderDeliveryType OrderDeliveryType { get; set; }
}
