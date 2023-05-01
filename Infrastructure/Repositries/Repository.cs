#nullable disable
using Domain.Repositries;
using Domain.Repositries.Common;
using Infrastructure.Extensions;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Infrastructure.Repositries
{
    internal class Repository<T> : IRepository<T> where T:class
    {
        private readonly ApplicationDbContext _context;
        public Repository(ApplicationDbContext context)
        {
            _context = context;
        }


        public async Task Create(T entity)
        {
            await _context.AddAsync(entity);
        }

        public Task<T> FirstOrDefualt(Expression<Func<T, bool>> filter, params Expression<Func<T, object>>[] propertySelectors)
        {
            var query = _context.Set<T>().AsQueryable();
            query = ApplayFilter(query, filter);
            query = IncludeLamda(query, propertySelectors);
            return query.FirstOrDefaultAsync();
        }

        public async Task<PageResult<T>> GetPage(PageRequest pageRequest, Expression<Func<T, bool>> filter, params Expression<Func<T, object>>[] propertySelectors)
        {
            var query = _context.Set<T>().AsQueryable();
            query = ApplayFilter(query, filter);

            var total = await query.CountAsync();

            query = IncludeLamda(query, propertySelectors);
            var data = pageRequest == null ? await query.ToListAsync() : await query.Skip((pageRequest.Page - 1) * pageRequest.Rows).Take(pageRequest.Rows).ToListAsync();
            return new PageResult<T>()
            {
                Data = data,
                TotalRecords = total,
            };
        }

        public void Update(T entity)
        {
            _context.Set<T>().Update(entity);
        }
        protected static IQueryable<T> ApplayFilter(IQueryable<T> query, Expression<Func<T, bool>> filter)
        {
            if (filter != null)
                query = query.Where(filter);
            return query;
        }
        protected static IQueryable<T> IncludeLamda(IQueryable<T> query, params Expression<Func<T, object>>[] includes)
        {
            if (includes?.Any() == true)
            {
                foreach (var item in includes)
                {
                    query = query.Include(item.AsPath());
                }
            }
            return query;
        }

        public void Delete(T entity)
        {
            _context.Remove(entity);
        }

        public async Task<IEnumerable<T>> GetAll(Expression<Func<T, bool>> filter, params Expression<Func<T, object>>[] propertySelectors)
        {
            var query = _context.Set<T>().AsQueryable();
            query = ApplayFilter(query, filter);
            query = IncludeLamda(query, propertySelectors);
            return await query.ToListAsync();

        }

        public void UpdateRange(IEnumerable<T> entities)
        {
            _context.Set<T>().UpdateRange(entities);
        }

        public async Task CreateRange(IEnumerable<T> entities)
        {
            await _context.AddRangeAsync(entities);
        }
    }
}
