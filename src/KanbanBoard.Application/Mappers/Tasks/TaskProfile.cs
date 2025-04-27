using AutoMapper;
using KanbanBoard.Application.Dtos.Tasks;
using KanbanBoard.Domain.Entities.Task;

namespace KanbanBoard.Application.Mappers.Task
{
    public class TaskProfile : Profile
    {
        public TaskProfile()
        {
            CreateMap<TaskEntity, TaskDto>().ReverseMap();
        }
    }
}
