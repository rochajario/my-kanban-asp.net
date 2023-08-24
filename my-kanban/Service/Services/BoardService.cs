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
            BoardEntity board = new BoardEntity()
            {
                Status = BoardState.Active,
                Name = boardDto.Name,
                Description = boardDto.Description,
                UpdatedAt = DateTime.UtcNow,
            };

            _boardRepository.Create(board);
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

        public void FinishAllChildrenTasks(int id)
        {
            BoardEntity board = _boardRepository.GetWithChildrenTasks(id);
            ValidateBoardState(board);

            var nonConcludedTasks = board.Tasks.Where(x => x.Status != TaskState.Concluded);
            foreach (var task in nonConcludedTasks)
            {
                task.Status = TaskState.Concluded;
            }

            _boardRepository.Update(board);
        }

        public IEnumerable<BoardEntity> GetAllBoards()
        {
            return _boardRepository.GetAll();
        }
    }
}
