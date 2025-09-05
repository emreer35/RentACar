using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentalsController : ControllerBase
    {
        IRentalService _rentalService;

        public RentalsController(IRentalService rentalService)
        {
            _rentalService = rentalService;
        }

        [HttpGet]
        [Route("getall")]
        public IActionResult GetAll()
        {
            var result = _rentalService.GetAll();
            if (result.Success) return Ok(result);
            return BadRequest(result);
        }
        
        [HttpPost]
        [Route("add")]
        public IActionResult Add(Rental rental)
        {
            var result = _rentalService.Add(rental);
            if (result.Success) return Created($"api/get/{rental.Id}", result);
            return BadRequest(result);
        }
        [HttpPost]
        [Route("update/{id:int}")]
        public IActionResult Update(int id, Rental rental)
        {
            rental.Id = id;
            var result = _rentalService.Update(rental);
            if (result.Success) return Ok(result);
            return BadRequest(result);
        }
        
    }
}
