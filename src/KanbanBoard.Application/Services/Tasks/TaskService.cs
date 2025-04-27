using AutoMapper;
using KanbanBoard.Application.Dtos.Tasks;
using KanbanBoard.Application.Interfaces.Repositories;
using KanbanBoard.Domain.Entities.Task;
using KanbanTask.Application.Interfaces.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KanbanBoard.Application.Services.Tasks
{
    internal class TaskService : ITaskService
    {
        private readonly IRepository<TaskEntity> repository;
        private readonly IMapper mapper;
        public TaskService(IRepository<TaskEntity> repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task<TaskDto> CreateTaskAsync(TaskDto createTaskDto)
        {
            var taskEntity = this.mapper.Map<TaskDto, TaskEntity>(createTaskDto);
            await this.repository.AddAsync(taskEntity);
            return this.mapper.Map<TaskEntity, TaskDto>(taskEntity);

        }

        public Task DeleteTaskAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<TaskDto>> GetAllTasksAsync()
        {
            var taskEntities = await this.repository.GetAllAsync();
            if (taskEntities == null || !taskEntities.Any())
            {
                return Enumerable.Empty<TaskDto>();
            }
            return this.mapper.Map<IEnumerable<TaskEntity>, IEnumerable<TaskDto>>(taskEntities);
        }

        public async Task<TaskDto> GetTaskByIdAsync(int id)
        {
            var taskEntity = await this.repository.GetByIdAsync(id);
            if (taskEntity == null)
            {
                throw new KeyNotFoundException($"Task with ID {id} not found.");
            }
            return this.mapper.Map<TaskEntity, TaskDto>(taskEntity);
        }

        public async Task UpdateTaskAsync(int id, TaskDto updateTaskDto)
        {
            // Retrieve the existing task entity by ID
            var existingTask = await this.repository.GetByIdAsync(id);
            if (existingTask == null)
            {
                throw new KeyNotFoundException($"Task with ID {id} not found.");
            }

            // Map the updated properties from the DTO to the existing entity
            this.mapper.Map(updateTaskDto, existingTask);

            // Update the task entity in the repository
            await this.repository.UpdateAsync(existingTask);
        }
    }
}
