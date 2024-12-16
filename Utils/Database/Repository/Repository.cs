using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Security.Principal;

namespace Utils.Database.Repository
{
    public class EFRepository<TDbContext, TEntity> : IRepository<TEntity>
       where TDbContext : DbContext
       where TEntity : class, IEntity
    {
        protected readonly TDbContext _dbContext;

        public EFRepository(TDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public DbSet<TEntity> Entities
            => _dbContext.Set<TEntity>();

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            await _dbContext.Set<TEntity>()
                            .AddAsync(entity);

            await _dbContext.SaveChangesAsync();

            return entity;
        }

        public async Task<IEnumerable<TEntity>> AddRangeAsync(IEnumerable<TEntity> entities)
        {
            await _dbContext.AddRangeAsync(entities);
            await _dbContext.SaveChangesAsync();

            return entities;
        }

        public async Task<TEntity> DeleteAsync(Guid id)
        {
            var current = await _dbContext.Set<TEntity>()
                                          .SingleAsync(i => i.Id == id);

            _dbContext.Set<TEntity>().Remove(current);

            await _dbContext.SaveChangesAsync();

            return current;
        }

        public Task<List<TEntity>> GetAsync()
            => _dbContext.Set<TEntity>()
                         .AsNoTracking()
                         .ToListAsync();

        public Task<TEntity?> GetByIdAsync(Guid id)
            => _dbContext.Set<TEntity>()
                         .AsNoTracking()
                         .FirstOrDefaultAsync(i => i.Id == id);

        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            var current = await _dbContext.Set<TEntity>()
                                          .SingleAsync(i => i.Id == entity.Id);

            _dbContext.Entry(current).CurrentValues.SetValues(entity);

            _dbContext.Set<TEntity>().Update(current);

            await _dbContext.SaveChangesAsync();

            return current;
        }
        public Task<bool> AnyAsync(Guid id)
               => _dbContext.Set<TEntity>()
                            .AnyAsync(i => i.Id == id);
    }
}
