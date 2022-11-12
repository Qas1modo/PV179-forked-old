using System;
using AutoMapper;
using Infrastructure.Repository;

namespace BL.Services.CRUD
{
	public class CRUDService<TDto, TEntity> where TDto: class where TEntity: class
	{
        private readonly IMapper _mapper;
        private readonly IRepository<TEntity> _repository;

        public CRUDService(IRepository<TEntity> repository, IMapper mapper)
		{
            _mapper = mapper;
            _repository = repository;
        }

        public void CreateAsync(TDto entity)
        {
            var newEnity = _mapper.Map<TEntity>(entity);
            _repository.Insert(newEnity);
        }

        public TDto GetByIdAsync(long id)
        {
           var result = _repository.GetByID(id);
           return _mapper.Map<TDto>(result);
        }

        public void UpdateAsync(TDto updateItem)
        {
            var updatedEntity = _mapper.Map<TEntity>(updateItem);
            _repository.Update(updatedEntity);
        }

        public void DeleteByIdAsync(long id)
        {
            _repository.Delete(id);
        }

        public void DeleteByEntityAsync(TDto deleteItem)
        {
            var deletedEntity = _mapper.Map<TEntity>(deleteItem);
            _repository.Delete(deletedEntity);
        }
    }
}
