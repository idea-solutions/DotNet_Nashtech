using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Assignment02.Models;
using Assignment02.Data;

namespace Assignment02.Repositories;

public class BaseRepository<T> : IBaseRepository<T> where T : class
{
    private readonly DbSet<T> _dbSet;
    private readonly ProductStoreContext _context;

    public BaseRepository(ProductStoreContext context)
    {
        _dbSet = context.Set<T>();
        _context = context;
    }

    public T Create(T entity)
    {
        return _dbSet.Add(entity).Entity;
    }

    public bool Delete(T entity)
    {
        _dbSet.Remove(entity);

        return true;
    }

    public IEntityDbTransaction EntityDbTransaction()
    {
        return new EntityDbTransaction(_context);
    }

    public IEnumerable<T> GetAll(Expression<Func<T, bool>>? predicate = null)
    {
        return predicate != null ? _dbSet.Where(predicate) : _dbSet;
    }

    public T? GetById(Expression<Func<T, bool>>? predicate = null)
    {
        return predicate != null ? _dbSet.FirstOrDefault(predicate) : _dbSet.FirstOrDefault();
    }

    public int SaveChanges()
    {
        return _context.SaveChanges();
    }

    public T Update(T entity)
    {
        return _dbSet.Update(entity).Entity;
    }
}