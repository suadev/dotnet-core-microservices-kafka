using System.Threading.Tasks;
using Shared.Kafka.Producer;

namespace Shared.Kafka
{
    public class KafkaMessageBus<Tk, Tv> : IKafkaMessageBus<Tk, Tv>
    {
        public readonly KafkaProducer<Tk, Tv> _producer;
        public KafkaMessageBus(KafkaProducer<Tk, Tv> producer)
        {
            _producer = producer;
        }
        public async Task PublishAsync(Tk key, Tv message)
        {
            await _producer.ProduceAsync(key, message);
        }
    }
}