using Domain.Enums;

namespace Domain.Entities
{
    public class BoardEntity : BaseEntity
    {
        public string Name { get; set; } = String.Empty;
        public string Description { get; set; } = String.Empty;
        public IEnumerable<TaskEntity> Tasks { get; set; } = new List<TaskEntity>();
        public DateTime UpdatedAt { get; set; }
        public BoardState Status { get; set; }
    }
}
