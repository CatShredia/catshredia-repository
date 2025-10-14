using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryAPI.Models;

public class Book
{
    [Key]
    public int id_book { get; set; }
    
    public string title { get; set; }
    public string author { get; set; }
    public int cost { get; set; }
    public string description { get; set; }
    
    // relation to 'genre' table
    [Required]
    [ForeignKey("Genre")]
    public int id_genre { get; set; }
    public Genre Genre { get; set; }
}