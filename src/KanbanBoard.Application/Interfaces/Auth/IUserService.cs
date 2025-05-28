using KanbanBoard.Application.Dtos.Auth.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KanbanBoard.Application.Interfaces.Auth
{
    public interface IUserService
    {
        Task<UserDto?> GetUserByUsernameAsync(string userId);
    }
}
