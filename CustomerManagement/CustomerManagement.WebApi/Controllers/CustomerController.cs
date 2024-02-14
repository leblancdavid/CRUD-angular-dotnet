using CustomerManagement.Services.Customers;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace CustomerManagement.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly ILogger<CustomerController> _logger;
        private readonly ICustomerService _customerService;

        public CustomerController(ILogger<CustomerController> logger,
            ICustomerService customerService)
        {
            _logger = logger;
            _customerService = customerService;
        }

        [HttpGet()]
        public async Task<IActionResult> Get()
        {
            try
            {
                return Ok(await _customerService.GetAllCustomersAsync());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return NotFound(ex.Message); 
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var customer = await _customerService.GetCustomerByIdAsync(id);
                if(customer == null)
                {
                    return NotFound();
                }
                return Ok(customer);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return NotFound(ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update(CustomerUpdateDto dto)
        {
            try
            {
                await _customerService.UpdateCustomerAsync(dto);
               
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return BadRequest(ex.Message);
            }

        }

        [HttpPost]
        public async Task<IActionResult> Add(NewCustomerDto dto)
        {
            try
            {
                var customer = await _customerService.AddCustomerAsync(dto);

                return Created($"Customer/{customer.Id}", customer);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return BadRequest(ex.Message);
            }

        }
    }
}