using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DistributedTaskSolving.Business.IGenerics.Entities;
using DistributedTaskSolving.EntityFrameworkCore.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace DistributedTaskSolving.EntityFrameworkCore.Repositories
{
    public class Repository<TEntity, TPrimaryKey> : IRepository<TEntity, TPrimaryKey>
        where TEntity : class, IEntity<TPrimaryKey>
    {
        private readonly ApplicationDbContext _dbContext;

        public Repository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public TEntity Get(TPrimaryKey id)
        {
            return _dbContext.Set<TEntity>()
                .SingleOrDefault(_ =>
                    EqualityComparer<TPrimaryKey>.Default
                        .Equals(id, _.Id));
        }

        public async Task<TEntity> GetAsync(TPrimaryKey id)
        {
            return await _dbContext.Set<TEntity>()
                .SingleOrDefaultAsync(_ =>
                    EqualityComparer<TPrimaryKey>.Default
                        .Equals(id, _.Id));
        }

        public IQueryable<TEntity> GetAll()
        {
            return _dbContext
                .Set<TEntity>();
        }

        public TEntity Insert(TEntity entity)
        {
            var inserted = _dbContext
                .Set<TEntity>()
                .Add(entity);

            return inserted.Entity;
        }

        public async Task<TEntity> InsertAsync(TEntity entity)
        {
            var inserted = await _dbContext
                .Set<TEntity>()
                .AddAsync(entity);

            return inserted.Entity;
        }

        public TEntity Update(TEntity entity)
        {
            var updated = _dbContext
                .Set<TEntity>()
                .Update(entity);

            return updated.Entity;
        }

        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            return Update(entity);
        }

        public void Delete(TEntity entity)
        {
            _dbContext
                .Set<TEntity>()
                .Remove(entity);
        }

        public async Task DeleteAsync(TEntity entity)
        {
            Delete(entity);
        }

        public void Delete(TPrimaryKey id)
        {
            var deleted = Get(id);

            Delete(deleted);
        }

        public async Task DeleteAsync(TPrimaryKey id)
        {
            var deleted = await GetAsync(id);

            await DeleteAsync(deleted);
        }

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }

        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}