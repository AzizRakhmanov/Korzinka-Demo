using Korzinka_Demo.DAL.DbContexts;
using Korzinka_Demo.DAL.IRepositories;
using Korzinka_Demo.Domain.Commons;
using Korzinka_Demo.Services.Pagination;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Korzinka_Demo.DAL.Repositories
{
    public class KorzinkaRepository<TEntity> : IKorzinkaRepository<TEntity> where TEntity : Auditable
    {
        protected readonly KorzinkaDbContext _context;

        protected readonly DbSet<TEntity> dbSet;

        public KorzinkaRepository(KorzinkaDbContext context)
        {
            this._context = context;
            this.dbSet = _context.Set<TEntity>();
        }

        public async ValueTask<bool> DeleteAsync(Expression<Func<TEntity, bool>> expression)
        {
            var @object = await this.SelectAsync(expression);
            this._context.Entry(@object).State = EntityState.Deleted;
            var result = this._context.SaveChanges();
            return result > 0;
        }

        public bool DeleteMany(Expression<Func<TEntity, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public async ValueTask<bool> InsertAsync(TEntity entity)
        {
            this._context.Entry(entity).State = EntityState.Added;
            var result = await this._context.SaveChangesAsync();
            return result > 0;
        }

        public async ValueTask SaveAsync()
        {
            await this._context.SaveChangesAsync();
        }

        public IQueryable<TEntity> SelectAll(Expression<Func<TEntity, bool>> expression, PaginationParams paginationParams)
        => this.dbSet.Where(expression).Skip((paginationParams.PageIndex - 1) * paginationParams.PageSize)
            .Take(paginationParams.PageSize);

        public async ValueTask<TEntity> SelectAsync(Expression<Func<TEntity, bool>> expression)
        => await this.dbSet.FirstOrDefaultAsync(expression);



        public void Update(TEntity entity)
        {
            this._context.Entry(entity).State = EntityState.Modified;
            this._context.SaveChangesAsync();
            return;
        }
    }
}
