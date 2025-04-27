using KanbanBoard.Application.Dtos.Board;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KanbanBoard.Application.Interfaces.Board
{
    public interface IBoardService
    {
        Task<BoardDto> CreateBoardAsync(BoardDto createBoardDto);
        Task<BoardDto> GetBoardByIdAsync(int id);
        Task<IEnumerable<BoardDto>> GetAllBoardsAsync();
        Task UpdateBoardAsync(int id, BoardDto updateBoardDto);
        Task DeleteBoardAsync(int id);
    }
}
