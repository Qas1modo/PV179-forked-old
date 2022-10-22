using System;
using DAL;
using Microsoft.EntityFrameworkCore;
using Infrastrucure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastrucure.EFCore.Repository
{
    public class EFGenericRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        internal BookReservationDbContext context;
        internal DbSet<TEntity> dbSet;

        public EFGenericRepository(BookReservationDbContext dbcontext)
        {
            context = dbcontext;
            dbSet = context.Set<TEntity>();
        }

        public virtual TEntity GetByID(object id)
        {
            if (id == null)
            {
                throw new Exception("Argument Id is null.");
            }

            TEntity? entity = dbSet.Find(id);
            if (entity == null)
            {
                throw new Exception("Entity with given Id does not exist.");
            }
            return entity;
        }

        public virtual void Insert(TEntity entity)
        {
            if (entity == null)
            {
                throw new Exception("Arugment entity is null");
            }

            dbSet.Add(entity);
        }

        public virtual void Delete(object id)
        {
            if (id == null)
            {
                throw new Exception("Argument Id is null.");
            }

            TEntity? entityToDelete = dbSet.Find(id);
            if (entityToDelete == null)
            {
                throw new Exception("Entity with given Id does not exist.");
            }
            Delete(entityToDelete);
        }

        public virtual void Delete(TEntity entityToDelete)
        {
            if (entityToDelete == null)
            {
                throw new Exception("Argument entityToDelete is null.");
            }

            if (context.Entry(entityToDelete).State == EntityState.Detached)
            {
                dbSet.Attach(entityToDelete);
            }
            dbSet.Remove(entityToDelete);
        }

        public virtual void Update(TEntity entityToUpdate)
        {
            if (entityToUpdate == null)
            {
                throw new Exception("Argument entityToUpdate is null.");
            }

            dbSet.Attach(entityToUpdate);
            context.Entry(entityToUpdate).State = EntityState.Modified;
        }
    }
}
