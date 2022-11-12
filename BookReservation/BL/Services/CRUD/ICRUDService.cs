using System;
using AutoMapper;
using Infrastructure.Repository;

namespace BL.Services.CRUD
{
	public interface ICRUDService<TDto, TEntity> where TDto : class where TEntity : class
    {
        public void CreateAsync(TDto entity);

        public TDto GetByIdAsync(long id);

        public void UpdateAsync(TDto updateItem);

        public void DeleteByIdAsync(long id);

        public void DeleteByEntityAsync(TDto deleteItem);
    }
}

