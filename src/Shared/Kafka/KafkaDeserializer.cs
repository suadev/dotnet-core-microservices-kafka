using System;
using System.Text;
using Confluent.Kafka;
using Newtonsoft.Json;

namespace Shared.Kafka
{
    internal sealed class KafkaDeserializer<T> : IDeserializer<T>
    {
        public T Deserialize(ReadOnlySpan<byte> data, bool isNull, SerializationContext context)
        {
            if (typeof(T) == typeof(Null))
            {
                if (data.Length > 0)
                {
                    throw new ArgumentException("Deserializer for Null may only be used to deserialize data that is null.");
                }

                return default;
            }

            if (typeof(T) == typeof(Ignore))
            {
                return default;
            }

            string exemplar = Encoding.UTF8.GetString(data);

            return JsonConvert.DeserializeObject<T>(exemplar);
        }
    }
}