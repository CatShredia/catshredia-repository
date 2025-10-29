using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using JwtProject.Model;

namespace JwtProject.Models;

public class Session
{
    [Key]
    public int id_session { get; set; }
    public string name { get; set; }
    
    // relation to 'user' table
    [Required]
    [ForeignKey("User")]
    public int id_user { get; set; }
    public User User { get; set; }
}