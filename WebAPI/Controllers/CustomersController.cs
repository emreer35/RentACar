using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        ICustomerService _customerService;

        public CustomersController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet]
        [Route("getall")]
        public IActionResult GetAll()
        {
            var result = _customerService.GetAll();
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }
        [HttpGet]
        [Route("get/{id:int}")]
        public IActionResult Get(int id)
        {
            var result = _customerService.Get(id);
            if (result.Success) return Ok(result);
            return BadRequest(result);
        }
        [HttpGet]
        [Route("user/{id:int}")]
        public IActionResult GetByUserId(int id)
        {
            var result = _customerService.GetByUserId(id);
            if (result.Success) return Ok(result);
            return BadRequest(result);
        }
        [HttpGet]
        [Route("customer-detail")]
        public IActionResult GetCustomerDetails()
        {
            var result = _customerService.GetCustomerDetails();
            if (result.Success) return Ok(result);
            return BadRequest(result);
        }
        [HttpGet]
        [Route("customer-detail/{id:int}")]
        public IActionResult GetCustomerDetailByUserId(int id)
        {
            var result = _customerService.GetCustomerDetailById(id);
            if (result.Success) return Ok(result);
            return BadRequest(result);
        }

        [HttpPost]
        [Route("add")]
        public IActionResult Add(Customer customer)
        {
            var result = _customerService.Add(customer);
            if (result.Success) return Created();
            return BadRequest(result);
        }
        [HttpPost]
        [Route("update/{id:int}")]
        public IActionResult Update(int id, Customer customer)
        {
            customer.Id = id;
            var result = _customerService.Update(customer);
            if (result.Success) return Ok(result);
            return BadRequest(result);
        }
        [HttpPost]
        [Route("delete/{id:int}")]
        public IActionResult Delete(int id, Customer customer)
        {
            customer.Id = id;
            var result = _customerService.Delete(customer);
            if (result.Success) return NoContent();
            return BadRequest(result);
        }
    }
}
