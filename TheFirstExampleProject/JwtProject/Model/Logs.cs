namespace JwtProject.Model;

public class Logs
{
    public int Id { get; set; }
    public string Method { get; set; } = null!;
    public string Url { get; set; } = null!;
    public string? UserId { get; set; }
    public string? IpAddress { get; set; }
    public string? Payload { get; set; } 
    public string? UserAgent { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}