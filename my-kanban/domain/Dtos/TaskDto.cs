using Domain.Entities;
using Domain.Enums;
using Domain.Interfaces;

namespace Domain.Dtos
{
    public class TaskDto : IDto<TaskEntity, TaskState>
    {
        public string Name { get; set; } = String.Empty;
        public string Description { get; set; } = String.Empty;

        public TaskEntity ToEntity(TaskState state = default)
        {
            return new TaskEntity()
            {
                Name = Name,
                Description = Description,
                UpdatedAt = DateTime.UtcNow,
                Status = state != default ? state : TaskState.Todo
            };
        }
    }
}
