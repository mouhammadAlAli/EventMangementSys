using AutoMapper;
using Domain.Base;
using Domain.Repositries;
using Domain.Repositries.Common;
using Domain.Services;
using System.Linq.Expressions;

namespace Application.Services
{
    internal class GenaricSerivce<TEntity, TDto, TCreate, TUpdate> : IGenaricSerivce<TEntity, TDto, TCreate, TUpdate> where TEntity : BaseEntity
    {
        protected readonly IRepository<TEntity> _repository;
        protected readonly IMapper _mapper;
        public GenaricSerivce(IRepository<TEntity> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public virtual Task Create(TCreate create)
        {
            var entity = _mapper.Map<TEntity>(create);
            return _repository.Create(entity);
        }

        public void Delete(TEntity entity)
        {
            _repository.Delete(entity);
        }

        public async Task Delete(int id)
        {
            var entity = await _repository.FirstOrDefualt(c => c.Id == id);
            _repository.Delete(entity);
        }

        public virtual async Task<TDto> FirstOrDefualt(Expression<Func<TEntity, bool>> filter, params Expression<Func<TEntity, object>>[] propertySelectors)
        {
            var entity = await _repository.FirstOrDefualt(filter, propertySelectors);
            return _mapper.Map<TDto>(entity);
        }

        public async Task<TEntity> FirstOrDefualtEntity(Expression<Func<TEntity, bool>> filter, params Expression<Func<TEntity, object>>[] propertySelectors)
        {
            return await _repository.FirstOrDefualt(filter, propertySelectors);
        }

        public async Task<IEnumerable<TDto>> GetAll(Expression<Func<TEntity, bool>> filter, params Expression<Func<TEntity, object>>[] propertySelectors)
        {
            var data = await _repository.GetAll(filter, propertySelectors);
            return _mapper.Map<IEnumerable<TDto>>(data);
        }

        public virtual async Task<PageResult<TDto>> GetPage(PageRequest pageRequest, Expression<Func<TEntity, bool>> filter, params Expression<Func<TEntity, object>>[] propertySelectors)
        {
            var result = await _repository.GetPage(pageRequest, filter, propertySelectors);
            return new PageResult<TDto>()
            {
                TotalRecords = result.TotalRecords,
                Data = _mapper.Map<IEnumerable<TDto>>(result.Data)
            };
        }

        public virtual Task Update(TUpdate update)
        {
            var updated = _mapper.Map<TEntity>(update);
            _repository.Update(updated);
            return Task.CompletedTask;
        }

        //public virtual Task Update(TUpdate update)
        //{
        //    var updated = _mapper.Map<TEntity>(update);
        //    _repository.Update(updated);
        //}
    }
}
