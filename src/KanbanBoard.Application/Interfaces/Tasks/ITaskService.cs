using KanbanBoard.Application.Dtos.Tasks;

namespace KanbanTask.Application.Interfaces.Tasks
{
    public interface ITaskService
    {
        Task<TaskDto> CreateTaskAsync(TaskDto createTaskDto);
        Task<TaskDto> GetTaskByIdAsync(int id);
        Task<IEnumerable<TaskDto>> GetAllTasksAsync();
        Task UpdateTaskAsync(int id, TaskDto updateTaskDto);
        Task DeleteTaskAsync(int id);
    }
}
