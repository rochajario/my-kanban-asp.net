using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Repository.Interfaces
{
    public interface IUnitOfWork
    {
        DbSet<BoardEntity> Boards { get; set; }
        DbSet<TaskEntity> Tasks { get; set; }
    }
}