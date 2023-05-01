using Domain.Base;
using Domain.Repositries.Common;
using System.Linq.Expressions;

namespace Domain.Repositries
{
    public interface IRepository<T>where T: class
    {
        Task Create(T entity);
        Task CreateRange(IEnumerable<T> entities);
        void Update(T entity);
        void UpdateRange(IEnumerable<T> entities);
        void Delete(T entity);
        Task<PageResult<T>> GetPage(PageRequest pageRequest, Expression<Func<T, bool>> filter, params Expression<Func<T, object>>[] propertySelectors);
        Task<IEnumerable<T>> GetAll(Expression<Func<T, bool>> filter, params Expression<Func<T, object>>[] propertySelectors);
        Task<T> FirstOrDefualt(Expression<Func<T, bool>> filter, params Expression<Func<T, object>>[] propertySelectors);
    }
}
