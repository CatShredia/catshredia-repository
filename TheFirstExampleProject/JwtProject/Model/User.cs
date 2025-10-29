using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JwtProject.Model;

public class User
{
    [Key]
    public int id_user { get; set; }

    public string name { get; set; }
    public string description { get; set; }
    
    // relation to 'role' table
    [Required]
    [ForeignKey("Role")]
    public int id_role { get; set; }
    public Role Role { get; set; }
}