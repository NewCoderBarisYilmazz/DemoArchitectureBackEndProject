using Business.Repositories.AuthRepository;
using Entities.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace WepApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
         private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("register")]
        public IActionResult Add ([FromForm]RegisterAuthDto authDto)
        {
             var result=  _authService.Register(authDto);
            if (result.Success)
           
                return Ok("Kayıt Başarılı");
            return BadRequest(result.Message);
            

        }

        [HttpPost("login")]
        public IActionResult Login(  LoginAuthDto authDto)
        {
            _authService.Login(authDto);
            return Ok("Login Olundu"  );
        }

    }
}
