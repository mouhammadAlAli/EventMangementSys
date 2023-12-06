using Domain.Base;
using Domain.Repositries.Common;
using System.Linq.Expressions;

namespace Domain.Services
{
    public interface IGenaricSerivce<TEntity, TDto, TCreate, TUpdate> where TEntity : BaseEntity
    {
        Task<PageResult<TDto>> GetPage(PageRequest pageRequest, Expression<Func<TEntity, bool>> filter, params Expression<Func<TEntity, object>>[] propertySelectors);
        Task<IEnumerable<TDto>> GetAll(Expression<Func<TEntity, bool>> filter, params Expression<Func<TEntity, object>>[] propertySelectors);
        Task Create(TCreate create);
        Task<TDto> FirstOrDefualt(Expression<Func<TEntity, bool>> filter, params Expression<Func<TEntity, object>>[] propertySelectors);
        Task<TEntity> FirstOrDefualtEntity(Expression<Func<TEntity, bool>> filter, params Expression<Func<TEntity, object>>[] propertySelectors);
        Task Update(TUpdate update);
        Task Delete(int id);
        void Delete(TEntity entity);

    }
}
