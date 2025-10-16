namespace LibraryAPI.Requests;

public class RentalStartQuery
{
    public DateOnly date_start {get; set;}
    
    public int id_book {get; set;}
    public int id_user {get; set;}
}