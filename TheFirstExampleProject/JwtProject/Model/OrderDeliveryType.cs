using System.ComponentModel.DataAnnotations;

namespace JwtProject.Model;

public class OrderDeliveryType
{
    [Key]
    public int id_delivery_type { get; set; }
    
    [Required]
    public string name { get; set; }
}