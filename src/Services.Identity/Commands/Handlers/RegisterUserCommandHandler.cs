using System.Threading.Tasks;
using System;
using System.Threading;
using Services.Identity.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Shared.Kafka;

namespace Services.Identity.Commands.Handlers
{
    public class RegisterUserCommandHandler : AsyncRequestHandler<RegisterUserCommand>
    {
        private readonly IdentityDBContext _dbContext;
        private readonly IKafkaMessageBus<string, User> _bus;

        public RegisterUserCommandHandler(IdentityDBContext dbContext, IKafkaMessageBus<string, User> bus)
        {
            _bus = bus;
            _dbContext = dbContext;
        }

        protected override async Task Handle(RegisterUserCommand command, CancellationToken cancellationToken)
        {
            if (await _dbContext.Users.AsNoTracking().AnyAsync(s => s.Email == command.Email))
                throw new ApplicationException("Email is already exist.");

            var user = new User
            {
                Id = command.Id,
                Password = command.Password,
                Email = command.Email,
                FirstName = command.FirstName,
                LastName = command.LastName,
                Address = command.Address
            };

            _dbContext.Users.Add(user);

            await _dbContext.SaveChangesAsync();

            await _bus.PublishAsync(command.Email, user);
        }
    }
}
