using System.ComponentModel.DataAnnotations;

namespace my_kanban_mvc.Models.Entities
{
    public class BoardEntity
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; } = String.Empty;
    }
}
