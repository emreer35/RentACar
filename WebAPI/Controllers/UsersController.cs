using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        [Route("getall")]
        public IActionResult GetAll()
        {
            var result = _userService.GetAll();
            if (result.Success) return Ok(result);
            return BadRequest(result);
        }
        [HttpGet]
        [Route("get/{id:int}")]
        public IActionResult Get(int id)
        {
            var result = _userService.Get(id);
            if (result.Success) return Ok(result);
            return BadRequest(result);
        }
        [HttpPost]
        [Route("add")]
        public IActionResult Add(User user)
        {
            var result = _userService.Add(user);
            if (result.Success) return Created($"api/get/{user.Id}", result);
            return BadRequest(result);
        }
        [HttpPost]
        [Route("update/{id:int}")]
        public IActionResult Update(int id, User user)
        {
            user.Id = id;
            var result = _userService.Update(user);
            if (result.Success) return Ok(result);
            return BadRequest(result);
        }
        [HttpPost]
        [Route("delete/{id:int}")]
        public IActionResult Delete(int id, User user)
        {
            user.Id = id;
            var result = _userService.Delete(user);
            if (result.Success) return Ok(result);
            return BadRequest(result);
        }
    }
}
