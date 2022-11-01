using Assignment01.Models;

namespace Assignment01.Services
{
    public interface ITaskService
    {
        List<TaskModel> GetAll();
        TaskModel? GetOne(Guid id);
        TaskModel AddTask(TaskModel task);
        TaskModel? EditTask(Guid id, TaskModel task);
        bool DeleteTask(Guid id);
        List<TaskModel> AddMulti(List<TaskModel> tasks);
        void DeleteMulti(List<Guid> ids);
    }
}