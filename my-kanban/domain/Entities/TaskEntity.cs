using Domain.Enums;

namespace Domain.Entities
{
    public class TaskEntity : BaseEntity
    {
        public string Name { get; set; } = String.Empty;
        public string Description { get; set; } = String.Empty;
        //public IEnumerable<string> Notes { get; set; } = new List<string>();
        public BoardEntity? Board { get; set; }
        public DateTime UpdatedAt { get; set; }
        public TaskState Status { get; set; }
    }
}
