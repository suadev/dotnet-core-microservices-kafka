using System.Threading.Tasks;

namespace Shared.Kafka
{
    public interface IMessagePublisher
    {
        Task Publish();
    }

    public class MessagePublisher : IMessagePublisher
    {
        public Task Publish()
        {
            throw new System.NotImplementedException();
        }
    }
}