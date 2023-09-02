using Domain.Dtos;
using Domain.Entities;
using Domain.Enums;

namespace Service.Interfaces
{
    public interface IBoardService
    {
        BoardEntity GetBoard(int id);
        void AddTask(int boardId, TaskDto task);
        void CreateBoard(BoardDto boardDto);
        void DeleteBoard(int id);
        void FinishBoardAllChildrenTasks(int id);
        IEnumerable<BoardEntity> GetAllBoards();
        BoardEntity GetBoardWithChildrenTasks(int id);
        void SetBoardState(int id, BoardState inactive);
    }
}
