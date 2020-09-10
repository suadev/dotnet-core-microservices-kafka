using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Services.Customer.Data;

namespace Services.Customer.Controllers
{
    [Route("api/customers")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly CustomerDBContext _dbContext;

        public CustomersController(CustomerDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> Get(Guid id)
        {
            return Ok(await _dbContext.Customers.FindAsync(id));
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            return Ok(await _dbContext.Customers.ToListAsync());
        }
    }
}