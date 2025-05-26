using KanbanBoard.Application.Dtos.Auth.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KanbanBoard.Application.Interfaces.Repositories.Auth
{
    public interface IUserRepository
    {
        Task<UserDto?> GetUserByUsernameAsync(string username);

    }
}
