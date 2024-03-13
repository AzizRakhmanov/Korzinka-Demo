
using Korzinka_Demo.DAL.DbContexts;
using Korzinka_Demo.DAL.IRepositories;
using Korzinka_Demo.Domain.Commons;
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
            var entity = await this.SelectAsync(expression);
            var result = this.dbSet.Remove(entity);

            if (result.State == EntityState.Deleted)
            {
                var res = await this._context.SaveChangesAsync();
                return res > 0;
            }
            return false;
        }

        public bool DeleteMany(Expression<Func<TEntity, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public async ValueTask<TEntity> InsertAsync(TEntity entity)
        {
            var entry = this.dbSet.Add(entity);
            await this._context.SaveChangesAsync();
            return entry.Entity;
        }

        public async ValueTask SaveAsync()
        {
            await this._context.SaveChangesAsync();
        }

        public IQueryable<TEntity> SelectAll(Expression<Func<TEntity, bool>> expression)
        => this.dbSet;

        public async ValueTask<TEntity> SelectAsync(Expression<Func<TEntity, bool>> expression)
        => await this.dbSet.FirstOrDefaultAsync(expression);



        public void Update(TEntity entity)
        {
            if (entity is not null)
            {
               this._context.Update(entity);
               var result = this._context.SaveChanges();
            }
            return;
        }
    }
}
