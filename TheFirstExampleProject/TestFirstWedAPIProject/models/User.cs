using System.ComponentModel.DataAnnotations;

namespace TestFirstWedAPIProject.models;

public class User
{
    // user table
    
    [Key]
    public int id_user { get; set; }
    
    public string name { get; set; }
    public string description { get; set; }
}