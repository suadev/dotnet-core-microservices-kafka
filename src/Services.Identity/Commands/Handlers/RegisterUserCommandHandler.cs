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
        // private readonly IMessagePublisher _messagePublisher;

        public RegisterUserCommandHandler(IdentityDBContext dbContext
        // , IMessagePublisher messagePublisher
        )
        {
            // _messagePublisher = messagePublisher;
            _dbContext = dbContext;
        }
        protected override async Task Handle(RegisterUserCommand command, CancellationToken cancellationToken)
        {
            if (await _dbContext.Users.AsNoTracking().AnyAsync(s => s.Email == command.Email))
                throw new ApplicationException("Email is already exist.");

            _dbContext.Users.Add(new User
            {
                Id = command.Id,
                Password = command.Password,
                Email = command.Email,
                FirstName = command.FirstName,
                LastName = command.LastName,
                Address = command.Address
            });

            await _dbContext.SaveChangesAsync();

            // await _messagePublisher.Publish();

            // new UserCreated(command.Id, command.Email, command.FirstName,
            //      command.LastName), null
        }
    }
}
