using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FitsController : ControllerBase
    {
        IFitService _fitService;
        public FitsController(IFitService fitService)
        {
            _fitService = fitService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _fitService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int fitId)
        {
            var result = _fitService.GetById(fitId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult Add(Fit fit)
        {
            var result = _fitService.Add(fit);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpPost("delete")]
        public IActionResult Delete(Fit fit)
        {
            var result = _fitService.Delete(fit);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update(Fit fit)
        {
            var result = _fitService.Update(fit);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
