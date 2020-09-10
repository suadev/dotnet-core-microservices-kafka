using System.Threading.Tasks;

namespace Shared.Kafka
{
    public interface IMessageSubscriber
    {
        Task Subscribe();
    }

    public class MessageSubscriber : IMessageSubscriber
    {
        public Task Subscribe()
        {
            throw new System.NotImplementedException();
        }
    }
}