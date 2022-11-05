using Data.Entities;

namespace WebAPI.Services
{
    public interface ITestService
    {
        Task<IEnumerable<Person>> Get();

        Task Add();
    }
}
