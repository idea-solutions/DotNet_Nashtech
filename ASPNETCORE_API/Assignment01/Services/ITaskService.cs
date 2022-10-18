using Assignment01.Models;

namespace Assignment01.Services
{
    public interface ITaskService
    {
        public List<TaskModel> GetAll();
        public TaskModel? GetOne(Guid id);
        public TaskModel AddTask(TaskModel task);
        public TaskModel? EditTask(TaskModel task);
        public bool DeleteTask(Guid id);
        public List<TaskModel> AddMulti(List<TaskModel> tasks);
        public void DeleteMulti(List<Guid> ids);
        // public bool Exist(Guid id);
    }
}