
using Assignment01.Models;

namespace Assignment01.Services
{
    public class TaskService : ITaskService
    {
        private static List<TaskModel> _taskList = new List<TaskModel>(){
            new TaskModel{
                TaskId = Guid.NewGuid(),
                Title = "Task 01",
                IsCompleted = true
            },
            new TaskModel{
                TaskId = Guid.NewGuid(),
                Title = "Task 02",
                IsCompleted = false
            },
            new TaskModel{
                TaskId = Guid.NewGuid(),
                Title = "Task 03",
                IsCompleted = true
            }
        };

        public TaskModel AddTask(TaskModel task)
        {

            var newTask = new TaskModel
            {
                TaskId = Guid.NewGuid(),
                Title = task.Title,
                IsCompleted = task.IsCompleted
            };
            _taskList.Add(newTask);

            return task;
        }

        public List<TaskModel> AddMulti(List<TaskModel> tasks)
        {
            _taskList.AddRange(tasks);
            return tasks;
        }

        public bool DeleteTask(Guid id)
        {
            var result = _taskList.FirstOrDefault(d => d.TaskId == id);
            if (result != null)
            {
                var data = _taskList.Remove(result);

                return data;
            }

            return false;
        }

        public void DeleteMulti(List<Guid> ids)
        {
            _taskList.RemoveAll(t => ids.Contains(t.TaskId));
        }

        public TaskModel? EditTask(Guid id, TaskModel task)
        {
            var result = _taskList.FirstOrDefault(task => task.TaskId == id);
            if (result != null)
            {
                result.Title = task.Title;
                result.IsCompleted = task.IsCompleted;

                return result;
            }
            return null;
        }

        public List<TaskModel> GetAll()
        {
            return _taskList;
        }

        public TaskModel? GetOne(Guid id)
        {
            return _taskList.FirstOrDefault(t => t.TaskId == id);
        }

    }
}