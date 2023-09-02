using Domain.Entities;
using Repository.Interfaces;

namespace Repository.Repsitories
{
    public class BoardRepository : BaseRepository<BoardEntity>, IBoardRepository
    {
        public BoardRepository(IUnitOfWork applicationContext) : base(applicationContext)
        {
        }

        public BoardEntity GetWithChildrenItems(int id)
        {
            var board = _context.Boards.Single(x => x.Id == id);
            _context.Entry(board).Collection(x => x.Tasks).Load();
            return board;
        }
    }
}
