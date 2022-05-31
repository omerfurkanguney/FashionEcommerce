using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PicturesController : ControllerBase
    {
        public static IWebHostEnvironment _webHostEnvironment;

        IPictureService _pictureService;
        public PicturesController(IPictureService pictureService, IWebHostEnvironment webHostEnvironment)
        {
            _pictureService = pictureService;
            _webHostEnvironment = webHostEnvironment;
        }

        [HttpPost("add")]
        public IActionResult Add([FromForm(Name = ("CarImage"))] IFormFile objectFile, [FromForm] Picture picture)
        {
            string path = _webHostEnvironment.WebRootPath + "\\uploads\\";
            var newGuidPath = Guid.NewGuid().ToString() + Path.GetExtension(objectFile.FileName);


            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            using (FileStream fileStream = System.IO.File.Create(path + newGuidPath))
            {
                objectFile.CopyTo(fileStream);
                fileStream.Flush();
            }
            if (objectFile == null)
            {
                picture.PicturePath = path + "default.png";
            }
            var result = _pictureService.Add(new Picture
            {
                ProductId = picture.ProductId,
                //Date = DateTime.Now,
                PicturePath = newGuidPath
            });
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getall")]
        public IActionResult Getall()
        {
            var result = _pictureService.GetAll();
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }


        [HttpGet("getImagesByCarId")]
        public IActionResult GetAllImagesByCarId(int pictureId)
        {
            var result = _pictureService.GetAllImagesByCarId(pictureId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getImagesById")]
        public IActionResult GetAllImagesById(int pictureId)
        {
            var result = _pictureService.GetById(pictureId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        //[HttpPost("delete")]
        //public IActionResult Delete(int pictureId)
        //{
        //    var result = _pictureService.Delete(pictureId);
        //    if (result.Success)
        //    {
        //        return Ok(result);
        //    }
        //    return BadRequest(result.Message);

        //}

        [HttpPost("update")]
        public IActionResult Update(Picture picture)
        {
            var result = _pictureService.Update(picture);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

    }
}
