using System;
using DAL;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DAL.Models;

namespace Infrastructure.EFCore.Repository
{
    public class EFGenericRepository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {
        internal BookReservationDbContext context;
        internal DbSet<TEntity> dbSet;

        public EFGenericRepository(BookReservationDbContext dbcontext)
        {
            context = dbcontext;
            dbSet = context.Set<TEntity>();
        }

        public virtual TEntity GetByID(int id)
        {
            TEntity? entity = dbSet.Find(id);
            if (entity == null)
            {
                throw new Exception("Entity with given Id does not exist.");
            }
            return entity;
        }

        public virtual int Insert(TEntity entity)
        {
            if (entity == null)
            {
                throw new Exception("Arugment entity is null");
            }
            return dbSet.Add(entity).Entity.Id;
        }

        public virtual void Delete(int id)
        {
            TEntity? entityToDelete = dbSet.Find(id);
            if (entityToDelete == null)
            {
                throw new Exception("Entity with given Id does not exist.");
            }
            dbSet.Remove(entityToDelete);
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
            if (entityToUpdate == null)
            {
                throw new Exception("Argument entityToUpdate is null.");
            }

            dbSet.Attach(entityToUpdate);
            context.Entry(entityToUpdate).State = EntityState.Modified;
        }

        public virtual IQueryable<TEntity> GetQueryable()
        {
            return dbSet.AsQueryable();
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            return dbSet.ToList();
        }
    }
}
