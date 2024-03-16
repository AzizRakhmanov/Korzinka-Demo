using Korzinka_Demo.Domain.Commons;
using Korzinka_Demo.Services.Pagination;
using System.Linq.Expressions;

namespace Korzinka_Demo.DAL.IRepositories
{
    public interface IKorzinkaRepository<TEntity> where TEntity : Auditable
    {
        public void Update(TEntity entity);

        public ValueTask<bool> InsertAsync(TEntity entity);

        public ValueTask<TEntity> SelectAsync(Expression<Func<TEntity, bool>> expression);

        public IQueryable<TEntity> SelectAll(Expression<Func<TEntity, bool>> expression, PaginationParams pagination);

        public ValueTask<bool> DeleteAsync(Expression<Func<TEntity, bool>> expression);

        public bool DeleteMany(Expression<Func<TEntity, bool>> expression);

        public ValueTask SaveAsync();
    }
}
