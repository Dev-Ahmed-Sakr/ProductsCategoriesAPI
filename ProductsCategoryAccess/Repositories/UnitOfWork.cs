using ProductsCategoriesAPI.Data;

namespace ProductsCategoryAccess.Repositories;

public class UnitOfWork:IUnitOfWork
{
    private readonly AppDbContext _context;
    private bool disposed = false;
    public UnitOfWork(AppDbContext contex)
    {
        _context = contex;
    }
    protected virtual void Dispose(bool disposing)
    {
        if (!this.disposed)
        {
            if (disposing)
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

    public AppDbContext GetContext()
    {
        return _context;
    }

    public void SaveChanges()
    {
        _context.SaveChanges();
    }
    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}
