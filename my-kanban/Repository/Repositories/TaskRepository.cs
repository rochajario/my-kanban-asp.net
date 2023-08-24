using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Repository.Interfaces;

namespace Repository.Repsitories
{
    public class TaskRepository : BaseRepository<TaskEntity>, ITaskRepository
    {
        public TaskRepository(IUnitOfWork applicationContext) : base(applicationContext)
        {
        }

        public TaskEntity GetWithParentItem(int id)
        {
            return _context
                .Tasks
                .Where(x => x.Id == id)
                .Include(x => x.Board)
                .SingleOrDefault()!;
        }
    }
}
