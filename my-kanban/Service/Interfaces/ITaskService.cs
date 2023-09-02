using Domain.Entities;
using Domain.Enums;

namespace Service.Interfaces
{
    public interface ITaskService
    {
        int ChangeTaskState(int taskId, TaskState taskState);
        TaskEntity GetTaskWithParentBoard(int taskId);
    }
}
