using Microsoft.EntityFrameworkCore;
using my_kanban_mvc.Models.Entities;

namespace my_kanban_mvc.Data
{
    public class ApplicationContext : DbContext
    {
        public DbSet<BoardEntity> Boards { get; set; }

        public ApplicationContext(DbContextOptions contextOptions) : base(contextOptions)
        {
        }
    }
}
