using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public interface IRepository<TEntity> where TEntity : class
    {
        public TEntity GetByID(int id);

        public IQueryable<TEntity> GetQueryable();

        public IEnumerable<TEntity> GetAll();

        public int Insert(TEntity entity);

        public void Delete(int id);

        public void Delete(TEntity entityToDelete);

        public void Update(TEntity entityToUpdate);
    }
}

