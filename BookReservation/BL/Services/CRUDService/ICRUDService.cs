using System;

namespace BL.Services.CRUDService
{
	public interface ICRUDService<TEntity> where TEntity : class
    {
        public object Create<TDto>(TDto insertItem);

        public TDto GetById<TDto>(object id);

        public void Update<TDto>(TDto updateItem);

        public void DeleteById(object id);

        public void DeleteByEntity<TDto>(TDto deleteItem);
    }
}

