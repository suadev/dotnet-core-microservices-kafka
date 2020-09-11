using Confluent.Kafka;

namespace Shared.Kafka.Consumer
{
    public class KafkaConsumerConfig<Tk, Tv> : ConsumerConfig
    {
        public KafkaConsumerConfig()
        {
            AutoOffsetReset = Confluent.Kafka.AutoOffsetReset.Earliest;
            EnableAutoOffsetStore = false;
        }

        public string Topic { get; set; }
        public bool Active { get; set; } = true;
    }
}