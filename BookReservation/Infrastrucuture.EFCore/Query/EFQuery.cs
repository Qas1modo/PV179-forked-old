﻿using DAL;
using DAL.Models;
using Infrastructure.Query;
using Infrastructure.UnitOfWork;
using Infrastructure.EFCore.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Reflection;

namespace Infrastructure.EFCore.Query
{
    public class EFQuery<TEntity> : Query<TEntity> where TEntity : BaseEntity, new()
    {
        private readonly BookReservationDbContext context;

        private readonly Type entityType;

        public EFQuery(BookReservationDbContext dbContext)
        {
            this.context = dbContext;
            this.entityType = typeof(TEntity);
        }

        public override EFQueryResult<TEntity> Execute()
        {
            IQueryable<TEntity> query = context.Set<TEntity>();
            foreach (var expression in WherePredicates)
            {
                query = ApplyWhere(query, expression.expression, expression.columnName);
            }
            if (OrderByData is not null)
            {
                query = OrderBy(query, OrderByData.Value.column, OrderByData.Value.ascending, OrderByData.Value.type);
            }
            if (PageNumber is not null)
            {
                query = query.Skip(((int)PageNumber - 1) * PageSize).Take(PageSize);
            }
            IEnumerable<TEntity> items = query.ToList();
            return new EFQueryResult<TEntity>(items, items.Count(), PageSize, PageNumber);
        }

        private IQueryable<TEntity> OrderBy(IQueryable<TEntity> query, string orderByColumn, bool ascending, Type orderType)
        {
            ParameterExpression parameter = Expression.Parameter(entityType, "parameter");
            string? objectName = entityType.GetProperty(orderByColumn)?.Name;
            if (objectName == null)
            {
                throw new ArgumentException($"Invalid column name: {orderByColumn}");
            }
            MemberExpression property = Expression.Property(parameter, objectName);
            var lambda = Expression.Lambda(property, parameter);
            var orderByMethod = typeof(Queryable).GetMethods()
                .First(a => a.Name == (ascending ? "OrderBy" : "OrderByDescending") && a.GetParameters().Length == 2);
            orderByMethod = orderByMethod.MakeGenericMethod(entityType, orderType);
            return (IQueryable<TEntity>)orderByMethod.Invoke(null, new object[] { query, lambda })!;
        }


        private IQueryable<TEntity> ApplyWhere(IQueryable<TEntity> query, Expression expression, string columnName)
        {
            ParameterExpression parameter = Expression.Parameter(entityType, "parameter");
            string? objectName = entityType.GetProperty(columnName)?.Name;
            if (objectName is null)
            {
                throw new ArgumentException($"Invalid column name: {columnName}");
            }
            MemberExpression property = Expression.Property(parameter, objectName);
            var getParameters = expression.GetType().GetProperty("Parameters")?.GetValue(expression);
            var getBody = expression.GetType().GetProperty("Body")?.GetValue(expression);
            if (getParameters is null || getBody is null)
            {
                throw new ArgumentException($"Expression is not supported: {expression}");
            }
            IReadOnlyCollection<ParameterExpression> parameters = (IReadOnlyCollection<ParameterExpression>)getParameters;
            ReplaceParamVisitor visitor = new(parameters.First(), property);
            Expression newBody = visitor.Visit((Expression) getBody);
            var lambda = Expression.Lambda<Func<TEntity, bool>>(newBody, parameter);
            return query.Where(lambda);
        }
    }
}
