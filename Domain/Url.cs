namespace Domain;

public class Url
{
    public Guid Id { get; set; }
    public string FullUrl { get; set; }
    public string ShortUrl { get; set; }
    
    public string Code { get; set; }
    public DateTime DateOfCreate { get; set; }
    public int Count { get; set; }
}