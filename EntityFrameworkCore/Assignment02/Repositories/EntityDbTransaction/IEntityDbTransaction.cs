
namespace Assignment02.Repositories
{

    public interface IEntityDbTransaction : IDisposable
    {
        void Commit();
        void Rollback();
    }
}