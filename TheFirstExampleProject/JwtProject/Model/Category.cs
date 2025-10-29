using System.ComponentModel.DataAnnotations;

namespace JwtProject.Model;

public class Category
{
    [Key]
    public int id_category { get; set; }

    public string name { get; set; }
    public string description { get; set; }
}