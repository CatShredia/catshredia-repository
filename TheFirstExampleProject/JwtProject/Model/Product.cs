using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JwtProject.Model;

public class Product
{
    [Key]
    public int id_product { get; set; }

    public string name { get; set; }
    public string description { get; set; }
    public int price { get; set; }
    public string stroke { get; set; }
    public bool is_active { get; set; }
    
    public DateOnly? created_at { get; set; }
    public DateOnly? updated_at { get; set; }
    
    // relation to 'category' table
    [Required]
    [ForeignKey("Category")]
    public int id_category { get; set; }
    public Category Category { get; set; }
}