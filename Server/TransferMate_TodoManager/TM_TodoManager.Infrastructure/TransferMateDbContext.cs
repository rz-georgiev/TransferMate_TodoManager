using Microsoft.EntityFrameworkCore;
using TM_TodoManager.Domain.Entities;
namespace TM_TodoManager.Infrastructure
{
    public class TransferMateDbContext(DbContextOptions<TransferMateDbContext> options) : DbContext(options)
    {
        public DbSet<Domain.Entities.UserTask> UserTasks { get; set; }

        public DbSet<Status> Statuses { get; set; }
    }
}
