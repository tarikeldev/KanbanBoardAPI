using KanbanBoard.Domain.Entities.Board;
using KanbanBoard.Domain.Entities.Task;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KanbanBoard.Infrastructure.Persistence.Configurations
{
    public class TaskConfiguration : IEntityTypeConfiguration<TaskEntity>
    {
        public void Configure(EntityTypeBuilder<TaskEntity> builder)
        {
            builder.HasKey(b => b.Id);
            builder.Property(b => b.Title)
                .IsRequired()
                .HasMaxLength(200);
            builder.HasOne<BoardEntity>()
                .WithMany()
                .HasForeignKey(b => b.BoardId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
