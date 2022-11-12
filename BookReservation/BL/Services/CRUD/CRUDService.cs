using System;
using AutoMapper;
using Infrastructure.Repository;
using BL.DTOs;

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

        public void CreateAsync(GenericDto insertItem)
        {
            if (insertItem == null)
            {
                throw new Exception("Arugment insertItem is null");
            }

            var newEnity = _mapper.Map<TEntity>(insertItem);
            _repository.Insert(newEnity);
        }

        public GenericDto GetByIdAsync(object id, GenericDto dto)
        {
            if (id == null)
            {
                throw new Exception("Argument Id is null.");
            }

            var result = _repository.GetByID(id);
            return (GenericDto)_mapper.Map(result, result.GetType(), dto.GetType());
        }

        public void UpdateAsync(GenericDto updateItem)
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

        public void DeleteByEntityAsync(GenericDto deleteItem)
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
