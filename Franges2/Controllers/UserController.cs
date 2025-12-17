using Microsoft.AspNetCore.Mvc;

namespace Franges2.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
    [HttpGet]
    public IActionResult GetUsers()
    {
        var users = new[] { "User1", "User2", "User3" };
        return Ok(users);
    }
    
}