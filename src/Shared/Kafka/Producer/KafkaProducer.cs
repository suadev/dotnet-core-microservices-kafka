using System;
using System.Threading.Tasks;
using Confluent.Kafka;
using Microsoft.Extensions.Options;

namespace Shared.Kafka.Producer
{
    public class KafkaProducer<Tk, Tv> : IDisposable
    {
        private readonly IProducer<Tk, Tv> _producer;
        private readonly string _topic;

        public KafkaProducer(IOptions<KafkaProducerConfig<Tk, Tv>> topicOptions, IProducer<Tk, Tv> producer)
        {
            _topic = topicOptions.Value.Topic;
            _producer = producer;
        }

        public void Dispose()
        {
            _producer.Dispose();
        }

        public async Task ProduceAsync(Tk key, Tv value)
        {
            await _producer.ProduceAsync(GetTopic(key, value), new Message<Tk, Tv> { Key = key, Value = value });
        }

        public virtual string GetTopic(Tk key, Tv value)
        {
            return _topic;
        }
    }
}