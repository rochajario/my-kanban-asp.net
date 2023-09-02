using Domain.Dtos;
using Domain.Entities;
using Domain.Enums;
using Repository.Interfaces;
using Service.Interfaces;

namespace Service.Services
{
    public class BoardService : IBoardService
    {
        private readonly IBoardRepository _boardRepository;

        public BoardService(IBoardRepository boardRepository)
        {
            _boardRepository = boardRepository;
        }

        public void CreateBoard(BoardDto boardDto)
        {
            _boardRepository.Create(boardDto.ToEntity());
        }

        public void DeleteBoard(int id)
        {
            var board = _boardRepository.Get(id);
            ValidateBoardState(board);
            _boardRepository.Delete(id);
        }

        private static void ValidateBoardState(BoardEntity board)
        {
            if (board.Status == BoardState.Inactive)
            {
                throw new InvalidOperationException("Board State Inactive.");
            }
        }

        public void FinishBoardAllChildrenTasks(int id)
        {
            BoardEntity board = _boardRepository.GetWithChildrenItems(id);
            ValidateBoardState(board);

            var nonConcludedTasks = board.Tasks.Where(x => x.Status != TaskState.Concluded);
            foreach (var task in nonConcludedTasks)
            {
                task.Status = TaskState.Concluded;
                task.UpdatedAt = DateTime.UtcNow;
            }
            board.UpdatedAt = DateTime.UtcNow;

            _boardRepository.Update(board);
        }

        public IEnumerable<BoardEntity> GetAllBoards()
        {
            return _boardRepository.GetAll();
        }

        public BoardEntity GetBoardWithChildrenTasks(int id)
        {
            return _boardRepository.GetWithChildrenItems(id);
        }

        public void SetBoardState(int id, BoardState state)
        {
            var entity = _boardRepository.Get(id);
            if (state != entity.Status)
            {
                entity.Status = state;
                entity.UpdatedAt = DateTime.UtcNow;
                _boardRepository.Update(entity);
            }
        }

        public BoardEntity GetBoard(int id)
        {
            return _boardRepository.Get(id);
        }

        public void AddTask(int boardId, TaskDto task)
        {
            TaskEntity taskEntity = task.ToEntity();
            BoardEntity board = GetBoardWithChildrenTasks(boardId);
            board.Tasks.Add(taskEntity);
            _boardRepository.Update(board);
        }
    }
}
