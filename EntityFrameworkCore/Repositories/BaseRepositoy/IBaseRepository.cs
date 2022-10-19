using System.Linq.Expressions;
using EntityFrameworkCore.Models;

namespace EntityFrameworkCore.Repositories;

public interface IBaseRepository<T> where T : BaseEntity<int>
{
    IEnumerable<T> GetAll(Expression<Func<T, bool>> predicate);
    T? GetOne(Expression<Func<T, bool>> predicate);
    T Create(T entity);
    T Update(T entity);
    bool Delete(T entity);
    int SaveChanges();
}