
using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ColorsController : ControllerBase
    {
        IColorService _colorService;

        public ColorsController(IColorService colorService)
        {
            _colorService = colorService;
        }

        [HttpGet]
        [Route("getall")]
        public IActionResult GetAll()
        {
            var result = _colorService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet]
        [Route("get/{id:int}")]
        public IActionResult Get(int id)
        {
            var result = _colorService.Get(id);
            if (result.Success) return Ok(result);
            return BadRequest(result);
        }
        [HttpPost]
        [Route("add")]
        public IActionResult Add(Color color)
        {
            var result = _colorService.Add(color);
            if (result.Success) return Created();
            return BadRequest(result);
        }
        [HttpPost]
        [Route("update/{id:int}")]
        public IActionResult Update(int id, Color color)
        {
            color.Id = id;
            var result = _colorService.Update(color);
            if (result.Success) return Ok(result);
            return BadRequest(result);
        }
        [HttpPost]
        [Route("delete/{id:int}")]
        public IActionResult Delete(int id, Color color)
        {
            color.Id = id;
            var result = _colorService.Delete(color);
            if (result.Success) return NoContent();
            return BadRequest(result);
        }
    }
}
