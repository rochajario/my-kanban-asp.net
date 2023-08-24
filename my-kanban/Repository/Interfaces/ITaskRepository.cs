using Domain.Entities;

namespace Repository.Interfaces
{
    public interface ITaskRepository : IRepository<TaskEntity>
    {
        TaskEntity GetWithParentItem(int id);
    }
}
