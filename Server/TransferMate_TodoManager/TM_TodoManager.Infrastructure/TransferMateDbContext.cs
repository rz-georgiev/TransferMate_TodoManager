using Microsoft.EntityFrameworkCore;
using TM_TodoManager.Core.Entities;

namespace TM_TodoManager.Infrastructure
{
    public class TransferMateDbContext(DbContextOptions<TransferMateDbContext> options) : DbContext(options)
    {
        public DbSet<UserTask> UserTasks { get; set; }

        public DbSet<Status> Statuses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Status>().HasData(
                new Status { Id = 1, Name = "ToDo" },
                new Status { Id = 2, Name = "InProgress" },
                new Status { Id = 3, Name = "Done" }
            );

            modelBuilder.Entity<UserTask>().HasData(
                new UserTask { Id = 1, Name = "Task1", DueDate = null, StatusId = 1 },
                new UserTask { Id = 2, Name = "Task2", DueDate = null, StatusId = 1 },
                new UserTask { Id = 3, Name = "Task3", DueDate = null, StatusId = 2 },
                new UserTask { Id = 4, Name = "Task4", DueDate = null, StatusId = 3 }
            );
        }
    }
}