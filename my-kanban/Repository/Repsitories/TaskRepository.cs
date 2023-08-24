using Domain.Entities;
using Repository.Interfaces;

namespace Repository.Repsitories
{
    public class TaskRepository : BaseRepository<TaskEntity>, IRepository<TaskEntity>
    {
        public TaskRepository(IUnitOfWork applicationContext) : base(applicationContext)
        {
        }
    }
}
