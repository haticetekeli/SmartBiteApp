using SmartBite.DataAccess.Entities;

namespace SmartBite.DataAccess.Repositories.Abstract
{
    public interface IRepository<TEntity> : IBaseRepository where TEntity : BaseEntity
    {
        TEntity Add(TEntity entity);
        IEnumerable<TEntity> AddRange(IEnumerable<TEntity> entities);
        TEntity Update(TEntity entity);
        TEntity Delete(TEntity entity);
        List<TEntity> Delete(List<TEntity> entities);
        IQueryable<TEntity> Query();
        IQueryable<TEntity> QueryAll();
    }
}
