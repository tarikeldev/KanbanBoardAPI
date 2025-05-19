using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KanbanBoard.WebApi.Controllers.Base
{
    [Authorize]
    [ApiController]
    public class ApiBaseController : ControllerBase
    {

    }
}
