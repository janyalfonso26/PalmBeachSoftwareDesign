using System.Data.Entity;

namespace DAL.Infrastructure
{
    public interface IUnitOfWork
    {
        /// <summary>
        /// Call this to commit the unit of work
        /// </summary>
        int Commit();

        /// <summary>
        /// Return the database reference for this UOW
        /// </summary>

        DbContext Db { get; }

        /// <summary>
        /// Starts a transaction on this unit of work
        /// </summary>
        void StartTransaction();

    }
}
