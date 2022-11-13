using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concreate;
using Microsoft.AspNetCore.Mvc;

namespace WepApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserOperationClaimsController : ControllerBase
    {
        private readonly IUserOperationClaimService _userOperationClaimservice;

        public UserOperationClaimsController(IUserOperationClaimService userOperationClaimservice)
        {
            _userOperationClaimservice = userOperationClaimservice;
        }

        [HttpPost("add")]
        public IActionResult Add(UserOperationClaim userOperationClaim)
        {
            _userOperationClaimservice.Add(userOperationClaim);
            return Ok("Kullanıcı yetkilendirme işlemi Başarılı");
        }
    }
}
