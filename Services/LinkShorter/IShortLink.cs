namespace Services.LinkShorter;

public interface IShortLink
{
   void GenerateShortUrl(string domen,string fullUrl);
   string Generator(string fullUrl);

}