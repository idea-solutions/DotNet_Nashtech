

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace Assignment02.Repositories
{

    public class EntityDbTransaction : IEntityDbTransaction
    {
        private IDbContextTransaction _transaction;
        public EntityDbTransaction(DbContext context)
        {
            _transaction = context.Database.BeginTransaction();
        }
        public void Commit()
        {
            _transaction.Commit();
        }

        public void Dispose()
        {
            _transaction.Dispose();
        }

        public void Rollback()
        {
            _transaction.Rollback();
        }
    }
}