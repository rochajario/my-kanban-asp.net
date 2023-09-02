using Domain.Entities;
using Domain.Enums;
using Repository.Interfaces;
using Service.Interfaces;

namespace Service.Services
{
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository _taskRepository;

        public TaskService(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public int ChangeTaskState(int taskId, TaskState taskState)
        {
            var task = GetTaskWithParentBoard(taskId);
            task.Status = taskState;
            _taskRepository.Update(task);
            return task.Board!.Id;
        }

        public TaskEntity GetTaskWithParentBoard(int taskId)
        {
            return _taskRepository.GetWithParentItem(taskId);
        }
    }
}
