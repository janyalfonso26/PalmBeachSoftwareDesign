using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace DAL.Infrastructure.EF
{
    public interface IRepository<TEntity>
    {
        IQueryable<TEntity> All();
        IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> criteria);

        bool Any();
        bool Any(Expression<Func<TEntity, bool>> criteria);

        TEntity Get(Expression<Func<TEntity, bool>> criteria);

        int Count();
        int Count(Expression<Func<TEntity, bool>> criteria);

        void Add(TEntity entity);
        void Delete(TEntity entity);
        void Delete(Expression<Func<TEntity, bool>> criteria);
        void Update(TEntity entity);
        int Max(Expression<Func<TEntity, int>> criteria);
    }
}
