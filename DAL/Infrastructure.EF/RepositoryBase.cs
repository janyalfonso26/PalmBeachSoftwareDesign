using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;

namespace DAL.Infrastructure.EF
{
    public abstract class RepositoryBase<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly IUnitOfWork _unitOfWork;

        #region Constructors

        protected RepositoryBase(IUnitOfWork unitOfWork)
        {
            if (unitOfWork == null) throw new ArgumentNullException("unitOfWork");
            _unitOfWork = unitOfWork;
        }

        #endregion

        #region Properties

        protected DbSet<TEntity> DbSet
        {
            get { return _unitOfWork.Db.Set<TEntity>(); }
        }

        #endregion

        #region Query Methods

        public virtual IQueryable<TEntity> All()
        {
            return DbSet.AsQueryable();
        }

        public virtual bool Any()
        {
            return DbSet.Local.Any() || DbSet.Any();
        }

        public virtual bool Any(Expression<Func<TEntity, bool>> criteria)
        {
            return DbSet.Local.Any(criteria.Compile()) || DbSet.Any(criteria);
        }

        public virtual IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> criteria)
        {
            return DbSet.Where(criteria);
        }

        public virtual TEntity Get(Expression<Func<TEntity, bool>> criteria)
        {
            return DbSet.Local.FirstOrDefault(criteria.Compile()) ?? DbSet.FirstOrDefault(criteria);
        }

        public bool Contains(Expression<Func<TEntity, bool>> criteria)
        {
            return Any(criteria);
        }

        public virtual int Count()
        {
            return All().Count();
        }

        public virtual int Count(Expression<Func<TEntity, bool>> criteria)
        {
            return Find(criteria).Count();
        }

        public virtual int Max(Expression<Func<TEntity, int>> criteria)
        {
            return DbSet.Max(criteria);
        }

        #endregion

        #region CRUD Methods

        public virtual void Add(TEntity entity)
        {
            DbSet.Add(entity);
            _unitOfWork.Commit();
        }

        public virtual void Update(TEntity entity)
        {
            var entry = _unitOfWork.Db.Entry(entity);
            DbSet.Attach(entity);           
            entry.State = EntityState.Modified;
            _unitOfWork.Commit();
        }

        public virtual void Delete(TEntity entity)
        {
            DbSet.Remove(entity);
            _unitOfWork.Commit();
        }

        public virtual void Delete(Expression<Func<TEntity, bool>> criteria)
        {
            var matches = Find(criteria);
            foreach (var obj in matches)
                DbSet.Remove(obj);
            _unitOfWork.Commit();
        }     

        #endregion

    }
}
