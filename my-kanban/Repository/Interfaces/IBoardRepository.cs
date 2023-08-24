using Domain.Entities;

namespace Repository.Interfaces
{
    public interface IBoardRepository : IRepository<BoardEntity>
    {
        BoardEntity GetWithChildrenTasks(int id);
    }
}
