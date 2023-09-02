using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Repository.Configurations
{
    public static class BoardEntityConfiguration
    {
        public static ModelBuilder ConfigureBoardEntity(this ModelBuilder builder)
        {
            builder
                .Entity<BoardEntity>()
                .HasMany(x => x.Tasks)
                .WithOne(x => x.Board);

            return builder;
        }
    }
}
