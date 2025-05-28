using KanbanBoard.Domain.Entities.Base;
using KanbanBoard.Domain.Entities.Board;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KanbanBoard.Domain.Entities.Task
{
    public class TaskEntity : BaseEntity
    {
        public string? Title { get; set; }
        public string? Description { get; set; }
        public Priority Priority { get; set; }

        public int BoardId { get; set; }
    }
}
