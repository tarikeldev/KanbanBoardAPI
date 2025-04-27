using KanbanBoard.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KanbanBoard.Domain.Entities.Board
{
    public class BoardEntity : BaseEntity
    {
        public string Title { get; set; }

    }
}
