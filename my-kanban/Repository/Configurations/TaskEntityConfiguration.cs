using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Repository.Configurations
{
    public static class TaskEntityConfiguration
    {
        public static ModelBuilder ConfigureTaskEntity(this ModelBuilder builder)
        {
            builder
                .Entity<TaskEntity>()
                .HasOne(x => x.Board)
                .WithMany(x => x.Tasks)
                .OnDelete(DeleteBehavior.ClientCascade);

            return builder;
        }
    }
}
