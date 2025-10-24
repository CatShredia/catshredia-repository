using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace LibraryAPI.Models;

public class RentList
{
    [Key]
    public int id_list { get; set; }
    public DateOnly date_start { get; set; }
    public DateOnly? date_end { get; set; }
    
    // relation to 'book' table
    [Required]
    [ForeignKey("Book")]
    public int id_book { get; set; }
    public Book Book { get; set; }
    
    // relation to 'user' table
    [Required]
    [ForeignKey("User")]
    public int id_user { get; set; }
    public User User { get; set; }
}