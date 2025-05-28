using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KanbanBoard.Domain.Entities.Base
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public string? Username { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
