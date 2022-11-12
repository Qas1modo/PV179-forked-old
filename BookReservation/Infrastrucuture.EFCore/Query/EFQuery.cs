using DAL;
using DAL.Models;
using Infrastructure.Query;
using Infrastructure.UnitOfWork;
using Infrastructure.EFCore.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Infrastructure.EFCore.Query
{
    public class EFQuery<TEntity> : Query<TEntity> where TEntity : BaseEntity, new()
    {
        private DbContext _context;

        public EFQuery(DbContext context)
        {
            _context = context;
            query = _context.Set<TEntity>().AsQueryable();
        }
        public override IEnumerable<TEntity> Execute()
        {
            return query.ToList();
        }
    }
}
