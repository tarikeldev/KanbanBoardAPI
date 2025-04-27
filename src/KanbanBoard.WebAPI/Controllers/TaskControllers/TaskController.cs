using KanbanBoard.Application.Dtos.Tasks;
using KanbanTask.Application.Interfaces.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace KanbanBoard.WebApi.Controllers.TaskControllers
{
    [ApiController]
    [Route("api/Tasks")]
    public class TaskController : ControllerBase
    {
        private readonly ITaskService _taskService;

        public TaskController(ITaskService taskService)
        {
            _taskService = taskService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateTask([FromBody] TaskDto createTaskDto)
        {
            var task = await _taskService.CreateTaskAsync(createTaskDto);
            return CreatedAtAction(nameof(GetTaskById), new { id = task.Id }, task);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTasks()
        {
            var tasks = await _taskService.GetAllTasksAsync();
            return Ok(tasks);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTaskById(int id)
        {
            var task = await _taskService.GetTaskByIdAsync(id);
            return task != null ? Ok(task) : NotFound();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTask(int id, [FromBody] TaskDto updateTaskDto)
        {
            await _taskService.UpdateTaskAsync(id, updateTaskDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTask(int id)
        {
            await _taskService.DeleteTaskAsync(id);
            return NoContent();
        }
    }
}
