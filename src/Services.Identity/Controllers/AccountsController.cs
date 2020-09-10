using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Identity.Commands;
using Services.Identity.Data;

namespace Services.Identity.Controllers
{
    [Route("api")]
    [ApiController]
    [AllowAnonymous]
    public class AccountsController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IdentityDBContext _dbContext;

        public AccountsController(IMediator mediator, IdentityDBContext dbContext)
        {
            _dbContext = dbContext;
            _mediator = mediator;
        }

        [HttpPost("sign-up")]
        public async Task<ActionResult> RegisterUser([FromBody] RegisterUserCommand command)
        {
            return Ok(await _mediator.Send(command));
        }
    }
}