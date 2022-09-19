namespace Services.UrlShorter;

public interface IShortLink
{
    string GetShortUrl(string fullUrl);
}