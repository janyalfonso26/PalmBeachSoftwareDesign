using System.Data.Entity;
using System.Transactions;
using DAL.Entities;

namespace DAL.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private TransactionScope _transaction;
        private readonly ExpensesContext _db;
        public DbContext Db
        {
            get { return _db; }
        }

        public UnitOfWork(ExpensesContext db)
        {
            _db = db;
        }

        public void StartTransaction()
        {
            if (_transaction == null)
                _transaction = new TransactionScope();
        }

        public int Commit()
        {
            var result = _db.SaveChanges();
            if (_transaction != null)
            {
                _transaction.Complete();
                _transaction.Dispose();
                _transaction = null;
            }
            return result;
        }

        private bool _disposed = false;
    }
}
