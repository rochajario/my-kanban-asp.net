using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Repository.Configurations;
using Repository.Interfaces;

namespace Repository
{
    public class ApplicationContext : DbContext, IUnitOfWork
    {
        public DbSet<BoardEntity> Boards { get; set; }
        public DbSet<TaskEntity> Tasks { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .ConfigureBoardEntity()
                .ConfigureTaskEntity();

            base.OnModelCreating(modelBuilder);
        }
    }
}