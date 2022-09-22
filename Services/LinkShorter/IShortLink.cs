namespace Services.LinkShorter;

public interface IShortLink
{
   void GenerateShortUrl(string fullUrl);
   string Generator(string fullUrl);

}