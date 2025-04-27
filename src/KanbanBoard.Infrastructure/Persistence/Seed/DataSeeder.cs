using KanbanBoard.Domain.Entities.Board;
using KanbanBoard.Infrastructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System;

namespace KanbanBoard.Infrastructure.Persistence.Seed
{
    public static class DataSeeder
    {
        public static async Task SeedAsync(ApplicationDbContext context)
        {
            if (!await context.Boards.AnyAsync())
            {
                var boards = new List<BoardEntity>
                {
                    new BoardEntity { Title = "To Do" },
                    new BoardEntity { Title = "In Progress"},
                    new BoardEntity { Title = "Review" },
                    new BoardEntity { Title = "Resolved" }
                };

                await context.Boards.AddRangeAsync(boards);
                await context.SaveChangesAsync();
            }
        }
    }
}
