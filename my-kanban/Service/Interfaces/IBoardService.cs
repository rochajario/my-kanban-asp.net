using Domain.Dtos;
using Domain.Entities;

namespace Service.Interfaces
{
    public interface IBoardService
    {
        void CreateBoard(BoardDto boardDto);
        void DeleteBoard(int id);
        void FinishAllChildrenTasks(int id);
        IEnumerable<BoardEntity> GetAllBoards();
    }
}
