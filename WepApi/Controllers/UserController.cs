using Business.Repositories.UserRepository;
using Microsoft.AspNetCore.Mvc;

namespace WepApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }
    
        [HttpGet("getAll")]
        public IActionResult GetAll()
        {
       var res=     _userService.GetAll();

            return Ok(res);
        }

    }
}
