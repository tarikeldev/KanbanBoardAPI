using KanbanBoard.Domain.Entities.Board;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KanbanBoard.Infrastructure.Persistence.Configurations
{
    public class BoardConfiguration : IEntityTypeConfiguration<BoardEntity>
    {
        public void Configure(EntityTypeBuilder<BoardEntity> builder)
        {
            builder.HasKey(b => b.Id);
            builder.Property(b => b.Title)
                .IsRequired()
                .HasMaxLength(200);
        }
    }
}
