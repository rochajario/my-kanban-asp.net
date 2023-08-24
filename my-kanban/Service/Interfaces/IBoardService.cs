using Domain.Dtos;
using Domain.Entities;
using Domain.Enums;

namespace Service.Interfaces
{
    public interface IBoardService
    {
        void CreateBoard(BoardDto boardDto);
        void DeleteBoard(int id);
        void FinishBoardAllChildrenTasks(int id);
        IEnumerable<BoardEntity> GetAllBoards();
        BoardEntity GetBoardWithChildrenTasks(int id);
        void SetBoardState(int id, BoardState inactive);
    }
}
