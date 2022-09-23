using Domain;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Reposiotory;

public class UrlRepository : IRepository<Url>
{
    private AppDbContext _context;

    public UrlRepository(AppDbContext context)
    {
        _context = context;
    }
    
    public IEnumerable<Url> GetAll()
    {
        return _context.Urls;
    }

    public Url GetUrl(Guid id)
    {
        return _context.Urls.SingleOrDefault(x=>x.Id==id);
    }

    public void Create(Url item)
    {
        _context.Urls.Add(item);
    }

    public void Edit(Url item)
    {
        _context.Entry(item).State = EntityState.Modified;
    }

    public void Delete(Guid id)
    {
        var url = _context.Urls.SingleOrDefault(x => x.Id == id);
        if (url != null)
            _context.Urls.Remove(url);
    }

    public Url GetUrlByShortUrl(string shortUrl)
    {
        var url = _context.Urls.FirstOrDefault(x => x.Code == shortUrl);
        return url;
    }

    public void Save()
    {
        _context.SaveChanges();
    }
    
    /// <summary>
    /// Disposing Connection
    /// </summary>
    private bool disposed = false;
    public virtual void Dispose(bool disposing)
    {
        if(!this.disposed)
        {
            if(disposing)
            {
                _context.Dispose();
            }
        }
        this.disposed = true;
    }
 
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
}