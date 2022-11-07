using Data.Entities;

namespace Data.Repositories
{
    public interface IBookRepository : IBaseRepository<Book>
    {
        Task<IEnumerable<Book>> GetAllIncludedAsync();
        Task<Book?> GetByIdIncludedAsync(int id);
    }
}