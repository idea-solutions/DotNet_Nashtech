using System.Linq.Expressions;
using Assignment02.Models;

namespace Assignment02.Repositories;

public interface IBaseRepository<T> where T : class
{
    IEnumerable<T> GetAll(Expression<Func<T, bool>> predicate);
    T? GetOne(Expression<Func<T, bool>> predicate);
    T Create(T entity);
    T Update(T entity);
    bool Delete(T entity);
    int SaveChanges();
    IEntityDbTransaction EntityDbTransaction();
}