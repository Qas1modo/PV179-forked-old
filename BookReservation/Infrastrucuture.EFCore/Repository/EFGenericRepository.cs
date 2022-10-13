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
            return dbSet.Find(id);
        }

        public virtual void Insert(TEntity entity)
        {
            dbSet.Add(entity);
        }

        public virtual void Delete(object id)
        {
            TEntity entityToDelete = dbSet.Find(id);
            Delete(entityToDelete);
        }

        public virtual void Delete(TEntity entityToDelete)
        {
            if (context.Entry(entityToDelete).State == EntityState.Detached)
            {
                dbSet.Attach(entityToDelete);
            }
            dbSet.Remove(entityToDelete);
        }

        public virtual void Update(TEntity entityToUpdate)
        {
            dbSet.Attach(entityToUpdate);
            context.Entry(entityToUpdate).State = EntityState.Modified;
        }
    }
}

