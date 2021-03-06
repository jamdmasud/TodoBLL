﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace UnitOfWorkRepository
{
    public interface IRepositoryQuery<TEntity> where TEntity : class
    {
        RepositoryQuery<TEntity> Filter(
            Expression<Func<TEntity, bool>> filter);

        RepositoryQuery<TEntity> OrderBy(
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy);

        RepositoryQuery<TEntity> Include(
            Expression<Func<TEntity, object>> expression);

        IEnumerable<TEntity> GetPage(
            int page, int pageSize, out int totalCount);

        IQueryable<TEntity> Get();
    }
}