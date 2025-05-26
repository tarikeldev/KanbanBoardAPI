using KanbanBoard.Application.Interfaces.Auth;
using KanbanBoard.WebApi.Controllers.Base;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace KanbanBoard.WebApi.Controllers.Auth
{
    [Route("api/[controller]")]
    public class UserController : ApiBaseController
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("current")]
        public async Task<IActionResult> GetCurrentUser()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (string.IsNullOrEmpty(userId))
                return Unauthorized();

            var user = await _userService.GetUserByUsernameAsync(userId);
            if (user == null)
                return NotFound();

            return Ok(user);
        }
    }
}