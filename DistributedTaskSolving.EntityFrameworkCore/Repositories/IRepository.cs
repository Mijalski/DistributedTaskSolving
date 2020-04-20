using System.Linq;
using System.Threading.Tasks;
using DistributedTaskSolving.Business.IGenerics.Entities;

namespace DistributedTaskSolving.EntityFrameworkCore.Repositories
{
    public interface IRepository<TEntity, in TPrimaryKey>
        where TEntity : class, IEntity<TPrimaryKey>
    {
        TEntity Get(TPrimaryKey id);
        Task<TEntity> GetAsync(TPrimaryKey id);
        IQueryable<TEntity> GetAll();
        TEntity Insert(TEntity entity);
        Task<TEntity> InsertAsync(TEntity entity);
        TEntity Update(TEntity entity);
        Task<TEntity> UpdateAsync(TEntity entity);
        void Delete(TEntity entity);
        Task DeleteAsync(TEntity entity);
        void Delete(TPrimaryKey id);
        Task DeleteAsync(TPrimaryKey id);
        void SaveChanges();
        Task SaveChangesAsync();
    }
}