using DataAccess;
using Domain;

namespace Services.LinkShorter;


public class ShortLink : IShortLink
{
    private AppDbContext _context;
    private const string chars = "AaBbCcDdEeFfGgHhIiGgKkLlMmNnOoPpQqRrSsTtUuVvWwXxYyZz0123456789";

    public ShortLink(AppDbContext context)
    {
        _context = context;
    }
    
    public void GenerateShortUrl(string domen,string fullUrl)
    {
        var shortUrl = Generator(fullUrl);
        while (_context.Urls.ToList().Where(x=>x.Code==shortUrl).Any())
        {
            shortUrl = Generator(fullUrl);
        }
        
        var url = new Url()
        {
            FullUrl = fullUrl,
            ShortUrl = domen+"/"+shortUrl,
            Code = shortUrl,
            DateOfCreate = DateTime.Now,
            Count = 0,
        };

        _context.Urls.Add(url);
        
        _context.SaveChanges();
    }

    public string Generator(string fullUrl)
    {
        return new string(Enumerable.Repeat(chars, new Random().Next(6, 7)).Select(s => s[new Random().Next(s.Length)])
            .ToArray());
    }
}