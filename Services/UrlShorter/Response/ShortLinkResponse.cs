namespace Services.UrlShorter.Response;

public class ShortLinkResponse
{
    public DateTime CreatedAt { get; set; }
    public string Id { get; set; }
    public string Link { get; set; }
    public object[] CustomBitlinks { get; set; }
    public string LongUrl { get; set; }
    public bool Archived { get; set; }
    public object[] Tags { get; set; }
    public object[] Deeplinks { get; set; }
}