namespace DataAccess;

public interface IRepository<T> : IDisposable
    where T: class
{
    IEnumerable<T> GetAll();
    T GetUrl(Guid id);
    void Create(T item);
    void Edit(T item);
    void Delete(Guid id);
    void Save();
}