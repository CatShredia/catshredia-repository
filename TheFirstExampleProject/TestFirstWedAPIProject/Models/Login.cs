using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestFirstWedAPIProject.models;

public class Login
{
    // login table
    
    [Key]
    public int id_login { get; set; }
    
    public string login { get; set; }
    public string password { get; set; }
    
    // relation to user table
    [Required]
    [ForeignKey("User")]
    public int id_user { get; set; }
    public User User { get; set; }
}