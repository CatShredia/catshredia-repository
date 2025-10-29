using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JwtProject.Model;

public class OrderList
{
    [Key]
    public int id_order_list { get; set; }
    
    // relation to 'order' table
    [Required]
    [ForeignKey("Order")]
    public int id_order { get; set; }
    public Order Order { get; set; }
    
    // relation to 'product' table
    [Required]
    [ForeignKey("Product")]
    public int id_product { get; set; }
    public Product Product { get; set; }
}