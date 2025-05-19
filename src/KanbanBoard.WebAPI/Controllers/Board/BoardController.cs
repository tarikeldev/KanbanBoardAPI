using KanbanBoard.Application.Dtos.Board;
using KanbanBoard.Application.Interfaces.Board;
using KanbanBoard.WebApi.Controllers.Base;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KanbanBoard.API.Controllers.Board
{

    [Route("api/boards")]
    public class BoardController : ApiBaseController
    {
        private readonly IBoardService _boardService;

        public BoardController(IBoardService boardService)
        {
            _boardService = boardService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateBoard([FromBody] BoardDto createBoardDto)
        {
            var board = await _boardService.CreateBoardAsync(createBoardDto);
            return CreatedAtAction(nameof(GetBoardById), new { id = board.Id }, board);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBoards()
        {
            var boards = await _boardService.GetAllBoardsAsync();
            return Ok(boards);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBoardById(int id)
        {
            var board = await _boardService.GetBoardByIdAsync(id);
            return board != null ? Ok(board) : NotFound();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBoard(int id, [FromBody] BoardDto updateBoardDto)
        {
            await _boardService.UpdateBoardAsync(id, updateBoardDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBoard(int id)
        {
            await _boardService.DeleteBoardAsync(id);
            return NoContent();
        }
    }
}
