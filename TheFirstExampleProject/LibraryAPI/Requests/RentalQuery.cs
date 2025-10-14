namespace LibraryAPI.Requests;

public class RentalQuery
{
    public DateOnly date_start {get; set;}
    public DateOnly date_end { get; set; }
    
    public int id_book {get; set;}
    public int id_user {get; set;}
}