using System;
using BL.DTOs;

namespace BL.Services.CRUD
{
	public interface ICRUDService<TEntity> where TEntity : class
    {
        public void CreateAsync(GenericDto insertItem);

        public GenericDto GetByIdAsync(object id, GenericDto dto);

        public void UpdateAsync(GenericDto updateItem);

        public void DeleteByIdAsync(object id);

        public void DeleteByEntityAsync(GenericDto deleteItem);
    }
}

