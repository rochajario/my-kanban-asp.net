using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
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
            var connectionString = Environment.GetEnvironmentVariable("CONNECTION_STRING");
            if (String.IsNullOrEmpty(connectionString))
            {
                throw new ArgumentException("Unable to obtain Environment Variable 'CONNECTION_STRING'.");
            }

            optionsBuilder
                .UseMySql(
                    connectionString!,
                    new MySqlServerVersion(new Version(8, 0, 31)),
                    x => x.EnableRetryOnFailure())
                .LogTo(Console.WriteLine, LogLevel.Information);

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