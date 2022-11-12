using System;
using AutoMapper;
using Infrastructure.Repository;

namespace BL.Services.CRUD
{
	public class CRUDService<TEntity> : ICRUDService<TEntity> where TEntity : class
    {
        private readonly IMapper _mapper;
        private readonly IRepository<TEntity> _repository;

        public CRUDService(IRepository<TEntity> repository, IMapper mapper)
		{
            _mapper = mapper;
            _repository = repository;
        }

        public void CreateAsync<TDto>(TDto insertItem)
        {
            if (insertItem == null)
            {
                throw new Exception("Arugment insertItem is null");
            }

            var newEnity = _mapper.Map<TEntity>(insertItem);
            _repository.Insert(newEnity);
        }

        public TDto GetByIdAsync<TDto>(object id)
        {
            if (id == null)
            {
                throw new Exception("Argument Id is null.");
            }

            var result = _repository.GetByID(id);
            return _mapper.Map<TDto>(result);
        }

        public void UpdateAsync<TDto>(TDto updateItem)
        {
            if (updateItem == null)
            {
                throw new Exception("Arugment updateItem is null");
            }


            var updatedEntity = _mapper.Map<TEntity>(updateItem);
            _repository.Update(updatedEntity);
        }

        public void DeleteByIdAsync(object id)
        {
            if (id == null)
            {
                throw new Exception("Argument Id is null.");
            }

            _repository.Delete(id);
        }

        public void DeleteByEntityAsync<TDto>(TDto deleteItem)
        {
            if (deleteItem == null)
            {
                throw new Exception("Argument deleteItem is null.");
            }

            var deletedEntity = _mapper.Map<TEntity>(deleteItem);
            _repository.Delete(deletedEntity);
        }
    }
}
