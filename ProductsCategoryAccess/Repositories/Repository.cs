namespace ProductsCategoryAccess.Repositories
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Query;
    using ProductsCategoriesAPI.Data;
    using System.Linq.Expressions;

    public class Repository<TEntity, TKey> : IRepository<TEntity, TKey> where TEntity : class
    {
        private readonly AppDbContext _context;

        public Repository(AppDbContext context)
        {
            _context = context;
        }
        public TEntity Add(TEntity entity)
        {
            return _context.Set<TEntity>().Add(entity).Entity;
        }

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            var addedEntity = (await _context.Set<TEntity>().AddAsync(entity)).Entity;
            return addedEntity;
        }

        public virtual void AddBulk(IEnumerable<TEntity> entities)
        {
            foreach (var Obj in entities)
            {
                Add(Obj);
            }

        }

        public virtual async Task AddBulkAsync(IEnumerable<TEntity> entities)
        {
            await _context.AddRangeAsync(entities);
        }

        public bool Any(Expression<Func<TEntity, bool>> predicate)
        {
            return _context.Set<TEntity>().Any(predicate);
        }
        public async Task<bool> AnyAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _context.Set<TEntity>().AnyAsync(predicate);
        }

        public TEntity Delete(TKey key)
        {
            TEntity entity = GetById(key);
            _context.Set<TEntity>().Remove(entity);
            return entity;
        }


        /// <summary>
        /// There is no need to use Save Changes after this action 
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public async Task<int> DeleteAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _context.Set<TEntity>().Where(predicate).ExecuteDeleteAsync();
        }

        public IQueryable<TEntity> GetAll()
        {
            return _context.Set<TEntity>();
        }

        public TEntity GetById(TKey key)
        {
            return _context.Set<TEntity>().Find(key);
        }
        public async ValueTask<TEntity> GetByIdAsync(TKey key)
        {
            return await _context.Set<TEntity>().FindAsync(key);
        }
        public IQueryable<TEntity> GetWhere(Expression<Func<TEntity, bool>> predicate)
        {
            return _context.Set<TEntity>().Where(predicate);
        }

        public async Task<List<TEntity>> GetWhereAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _context.Set<TEntity>().Where(predicate).ToListAsync();
        }
        public async Task<TEntity?> GetFirstAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _context.Set<TEntity>().Where(predicate).FirstOrDefaultAsync();
        }
        public virtual async Task UpdateAsync(TEntity entity)
        {

            _context.Update(entity);

        }
        public async Task<int> UpdateBulkAsync(Expression<Func<TEntity, bool>> whereCondition, Expression<Func<SetPropertyCalls<TEntity>, SetPropertyCalls<TEntity>>> setPropertyCalls)
        {
            return await _context.Set<TEntity>().Where(whereCondition).ExecuteUpdateAsync(setPropertyCalls);
        }
    }

}
