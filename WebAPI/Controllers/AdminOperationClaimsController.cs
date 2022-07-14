using Business.Abstract;
using Core.Entities.Concrete;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminOperationClaimsController : ControllerBase
    {
        IAdminOperationClaimService _claimService;
        public AdminOperationClaimsController(IAdminOperationClaimService claimService)
        {
            _claimService = claimService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _claimService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int claimId)
        {
            var result = _claimService.GetById(claimId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult Add(AdminOperationClaim adminOperationClaim)
        {
            var result = _claimService.Add(adminOperationClaim);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
      

        [HttpPost("delete")]
        public IActionResult Delete(AdminOperationClaim adminOperationClaim)
        {
            var result = _claimService.Delete(adminOperationClaim);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update(AdminOperationClaim adminOperationClaim)
        {
            var result = _claimService.Update(adminOperationClaim);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
