using System.ComponentModel.DataAnnotations;

namespace JwtProject.Model;

public class OrderStatus
{
    [Key]
    public int id_status { get; set; }
    
    [Required]
    public string name { get; set; }
}