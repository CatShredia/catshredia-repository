using System.ComponentModel.DataAnnotations;

namespace LibraryAPI.Models;

public class Role
{
    [Key]
    public int id_role { get; set; }
    public string name { get; set; }
}