namespace ProductsCategoryAccess.Repositories
{
    using Microsoft.EntityFrameworkCore.Query;
    using System.Linq.Expressions;

    public interface IRepository<TEntity, TKey> where  TEntity : class
    {
        IQueryable<TEntity> GetAll();
        IQueryable<TEntity> GetWhere(Expression<Func<TEntity, bool>> predicate);
        Task<List<TEntity>> GetWhereAsync(Expression<Func<TEntity, bool>> predicate);
        Task<TEntity?> GetFirstAsync(Expression<Func<TEntity, bool>> predicate);

        TEntity Add(TEntity entity);
        void AddBulk(IEnumerable<TEntity> entities);
        Task AddBulkAsync(IEnumerable<TEntity> entities);
        TEntity GetById(TKey key);
        ValueTask<TEntity> GetByIdAsync(TKey key);
        bool Any(Expression<Func<TEntity, bool>> predicate);
        Task<bool> AnyAsync(Expression<Func<TEntity, bool>> predicate);
        TEntity Delete(TKey key);
        Task<int> DeleteAsync(Expression<Func<TEntity, bool>> predicate);
        Task<TEntity> AddAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
        Task<int> UpdateBulkAsync(Expression<Func<TEntity, bool>> whereCondition, Expression<Func<SetPropertyCalls<TEntity>, SetPropertyCalls<TEntity>>> setPropertyCalls);

    }

}
