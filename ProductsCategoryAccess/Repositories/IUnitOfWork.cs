using ProductsCategoriesAPI.Data;

namespace ProductsCategoryAccess.Repositories;

public interface IUnitOfWork: IDisposable
{
    void SaveChanges();
    Task SaveChangesAsync();
    AppDbContext GetContext();
}
