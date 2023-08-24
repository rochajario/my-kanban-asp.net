using Domain.Entities;

namespace Repository.Interfaces
{
    public interface IBoardRepository : IRepository<BoardEntity>
    {
        BoardEntity GetWithChildrenItems(int id);
    }
}
