using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseProductsController : ControllerBase
    {
        IBaseProductService _baseProductService;
        public BaseProductsController(IBaseProductService baseProductService)
        {
            _baseProductService = baseProductService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _baseProductService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getbyid")]
        public IActionResult GetById(int baseProductId)
        {
            var result = _baseProductService.GetById(baseProductId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult Add(BaseProduct baseProduct)
        {
            var result = _baseProductService.Add(baseProduct);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(BaseProduct baseProduct)
        {
            var result = _baseProductService.Delete(baseProduct);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update(BaseProduct baseProduct)
        {
            var result = _baseProductService.Update(baseProduct);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
