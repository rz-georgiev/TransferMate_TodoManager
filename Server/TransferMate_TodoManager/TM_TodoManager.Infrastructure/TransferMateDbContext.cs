using Microsoft.EntityFrameworkCore;
using TM_TodoManager.Core.Entities;

namespace TM_TodoManager.Infrastructure
{
    public class TransferMateDbContext(DbContextOptions<TransferMateDbContext> options) : DbContext(options)
    {
        public DbSet<UserTask> UserTasks { get; set; }

        public DbSet<Status> Statuses { get; set; }

        // Seeding db with default data
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Status>().HasData(
                new Status { Id = 1, Name = "ToDo" },
                new Status { Id = 2, Name = "InProgress" },
                new Status { Id = 3, Name = "Done" }
            );

            modelBuilder.Entity<UserTask>().HasData(
                new UserTask { Id = 1, Name = "Task1", DueDate = DateTime.UtcNow.AddDays(1), StatusId = 1 },
                new UserTask { Id = 2, Name = "Task2", DueDate = DateTime.UtcNow.AddDays(2), StatusId = 1 },
                new UserTask { Id = 3, Name = "Task3", DueDate = DateTime.UtcNow.AddDays(-1), StatusId = 2 },
                new UserTask { Id = 4, Name = "Task4", DueDate = DateTime.UtcNow.AddDays(-2), StatusId = 2 },
                new UserTask { Id = 5, Name = "Task5", DueDate = DateTime.UtcNow.AddDays(-3), StatusId = 2 }
            );
        }
    }
}