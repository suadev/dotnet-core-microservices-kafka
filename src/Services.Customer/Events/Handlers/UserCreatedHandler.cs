using System.Threading.Tasks;
using Services.Customer.Data;
using Services.Customer.Messages;
using Shared.Kafka.Consumer;

namespace Services.Customer.Handlers
{
    public class UserCreatedHandler : IKafkaHandler<string, User>
    {
        private readonly CustomerDBContext _dbContext;

        public UserCreatedHandler(CustomerDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task HandleAsync(string key, User value)
        {
            _dbContext.Customers.Add(new Customer.Data.Customer
            {
                Id = value.Id,
                Email = value.Email,
                FirstName = value.FirstName,
                LastName = value.LastName,
            });

            await _dbContext.SaveChangesAsync();
        }
    }
}