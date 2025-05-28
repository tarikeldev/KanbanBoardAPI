using KanbanBoard.Application.Dtos.Auth.User;
using KanbanBoard.Application.Interfaces.Auth;
using KanbanBoard.Application.Interfaces.Repositories.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KanbanBoard.Application.Services.Auth
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<UserDto?> GetUserByUsernameAsync(string username)
        {
             var user = await _userRepository.GetUserByUsernameAsync(username);
            if (user == null) return null;

            return new UserDto
            {
                Id = user.Id,
                UserName = user.UserName,
                Email = user.Email
            };
        }

    }
}
