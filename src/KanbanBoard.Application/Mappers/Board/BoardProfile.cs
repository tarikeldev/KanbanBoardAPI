using AutoMapper;
using KanbanBoard.Application.Dtos.Board;
using KanbanBoard.Domain.Entities.Board;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KanbanBoard.Application.Mappers.Board
{
    public class TaskProfile : Profile
    {
        public TaskProfile()
        {
            CreateMap<BoardEntity, BoardDto>().ReverseMap();
        }
    }
}
