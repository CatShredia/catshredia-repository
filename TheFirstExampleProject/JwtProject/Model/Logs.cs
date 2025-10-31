namespace JwtProject.Model;

public class Logs
{
    public int Id { get; set; }
    public string Method { get; set; } = null!;
    public string Url { get; set; } = null!;
    public string? UserAgent { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}