using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Repository.Interfaces;

namespace Repository.Repsitories
{
    public class BoardRepository : BaseRepository<BoardEntity>, IBoardRepository
    {
        public BoardRepository(IUnitOfWork applicationContext) : base(applicationContext)
        {
        }

        public BoardEntity GetWithChildrenTasks(int id)
        {
            return _context
                .Boards
                .Where(x => x.Id == id)
                .Include(x => x.Tasks)
                .SingleOrDefault()!;
        }
    }
}
