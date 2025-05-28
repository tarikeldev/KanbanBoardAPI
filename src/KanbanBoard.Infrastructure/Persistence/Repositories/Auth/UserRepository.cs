using KanbanBoard.Application.Dtos.Auth.User;
using KanbanBoard.Application.Interfaces.Repositories.Auth;
using KanbanBoard.Infrastructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace KanbanBoard.Infrastructure.Persistence.Repositories.Auth
{
    public class UserRepository : IUserRepository
    {
        // Inject your DbContext or data source here
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<UserDto?> GetUserByUsernameAsync(string username)
        {
            var user = await _context.Users
                   .FirstOrDefaultAsync(u => u.UserName == username); if (user == null) return null;
            return new UserDto
            {
                Id = user.Id,
                UserName = user.UserName,
                Email = user.Email
            };
        }
    }
}
