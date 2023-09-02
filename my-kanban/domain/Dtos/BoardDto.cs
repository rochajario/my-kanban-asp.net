using Domain.Entities;
using Domain.Enums;
using Domain.Interfaces;

namespace Domain.Dtos
{
    public class BoardDto : IDto<BoardEntity, BoardState>
    {
        public string Name = String.Empty;
        public string Description = String.Empty;

        public BoardEntity ToEntity(BoardState state = default)
        {
            return new BoardEntity()
            {
                Name = Name,
                Description = Description,
                UpdatedAt = DateTime.UtcNow,
                Status = state != default ? state : BoardState.Active
            };
        }
    }
}
