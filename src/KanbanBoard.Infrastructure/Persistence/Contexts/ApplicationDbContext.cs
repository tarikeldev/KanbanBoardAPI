using KanbanBoard.Domain.Entities.Board;
using KanbanBoard.Domain.Entities.Task;
using KanbanBoard.Infrastructure.Persistence.Configurations;
using Microsoft.EntityFrameworkCore;

namespace KanbanBoard.Infrastructure.Persistence.Contexts
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<TaskEntity> Tasks { get; set; }
        public DbSet<BoardEntity> Boards { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new BoardConfiguration());
            modelBuilder.ApplyConfiguration(new TaskConfiguration());
        }
    }
}
