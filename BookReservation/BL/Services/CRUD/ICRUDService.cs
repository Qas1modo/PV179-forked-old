using System;

namespace BL.Services.CRUD
{
	public interface ICRUDService<TEntity> where TEntity : class
    {
        public void CreateAsync<TDto>(TDto insertItem);

        public TDto GetByIdAsync<TDto>(object id);

        public void UpdateAsync<TDto>(TDto updateItem);

        public void DeleteByIdAsync(object id);

        public void DeleteByEntityAsync<TDto>(TDto deleteItem);
    }
}

