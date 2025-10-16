namespace LibraryAPI.Requests;

public class RentalEndQuery
{
    public DateOnly date_end { get; set; }
    
    public int id_rental {get; set;}
}