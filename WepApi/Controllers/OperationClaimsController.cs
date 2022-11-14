using Business.Repositories.OperationClaimRepository;
using Entities.Concreate;
using Microsoft.AspNetCore.Mvc;

namespace WepApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OperationClaimsController : ControllerBase
    {
        private readonly IOperationClaimService _operationClaimService;

        public OperationClaimsController(IOperationClaimService operationClaimService)
        {
            _operationClaimService = operationClaimService;
        }


        [HttpPost("add")]
        public IActionResult Add (OperationClaim operationClaim)
        {
            _operationClaimService.Add(operationClaim);
            return Ok("Kayıt İşlemi Başarılı");
        }
    }
}
