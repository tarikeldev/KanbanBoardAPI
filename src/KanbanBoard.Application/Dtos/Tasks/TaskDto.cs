using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KanbanBoard.Application.Dtos.Tasks
{
    public class TaskDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int? UserId { get; set; }
        public string? Username { get; set; }
        public DateTime CreatedAt { get; set; }
        public int BoardId { get; set; }
    }
}
