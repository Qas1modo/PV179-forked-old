using System;

namespace BL.Services.CRUD
{
	public interface ICRUDService<TDto, TEntity> where TDto : class where TEntity : class
    {
        public void CreateAsync(TDto insertItem);

        public TDto GetByIdAsync(object id);

        public void UpdateAsync(TDto updateItem);

        public void DeleteByIdAsync(object id);

        public void DeleteByEntityAsync(TDto deleteItem);
    }
}

