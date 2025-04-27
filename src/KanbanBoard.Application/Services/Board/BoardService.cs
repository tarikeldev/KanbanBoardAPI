using AutoMapper;
using KanbanBoard.Application.Dtos.Board;
using KanbanBoard.Application.Interfaces.Board;
using KanbanBoard.Application.Interfaces.Repositories;
using KanbanBoard.Domain.Entities.Board;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KanbanBoard.Application.Services.Board
{
    public class BoardService : IBoardService
    {
        private readonly IRepository<BoardEntity> repository;
        private readonly IMapper mapper;

        public BoardService(IRepository<BoardEntity> repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task<BoardDto> CreateBoardAsync(BoardDto createBoardDto)
        {
            // Map the DTO to the entity
            var boardEntity = this.mapper.Map<BoardDto, BoardEntity>(createBoardDto);

            // Add the entity to the repository
            await this.repository.AddAsync(boardEntity);

            // Map the created entity back to a DTO and return it
            return this.mapper.Map<BoardEntity, BoardDto>(boardEntity);
        }

        public async Task DeleteBoardAsync(int id)
        {
            // Check if the board exists
            var existingBoard = await this.repository.GetByIdAsync(id);
            if (existingBoard == null)
            {
                throw new KeyNotFoundException($"Board with ID {id} not found.");
            }

            // Delete the board
            await this.repository.DeleteAsync(id);
        }

        public async Task<IEnumerable<BoardDto>> GetAllBoardsAsync()
        {
            // Retrieve all board entities
            var boardEntities = await this.repository.GetAllAsync();

            // Map the entities to DTOs and return them
            return this.mapper.Map<IEnumerable<BoardEntity>, IEnumerable<BoardDto>>(boardEntities);
        }

        public async Task<BoardDto> GetBoardByIdAsync(int id)
        {
            // Retrieve the board entity by ID
            var boardEntity = await this.repository.GetByIdAsync(id);
            if (boardEntity == null)
            {
                throw new KeyNotFoundException($"Board with ID {id} not found.");
            }

            // Map the entity to a DTO and return it
            return this.mapper.Map<BoardEntity, BoardDto>(boardEntity);
        }

        public async Task UpdateBoardAsync(int id, BoardDto updateBoardDto)
        {
            // Retrieve the existing board entity by ID
            var existingBoard = await this.repository.GetByIdAsync(id);
            if (existingBoard == null)
            {
                throw new KeyNotFoundException($"Board with ID {id} not found.");
            }

            // Map the updated properties from the DTO to the existing entity
            this.mapper.Map(updateBoardDto, existingBoard);

            // Update the board entity in the repository
            await this.repository.UpdateAsync(existingBoard);
        }
    }

}
