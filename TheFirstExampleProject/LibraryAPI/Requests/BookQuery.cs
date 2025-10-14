namespace LibraryAPI.Requests;

public class BookQuery
{
    public string title { get; set; }
    public string author { get; set; }
    public int cost { get; set; }
    public string description { get; set; }

    public string genre_name { get; set; }
}