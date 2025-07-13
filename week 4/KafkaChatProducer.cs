using Confluent.Kafka;
using System;
using System.Threading.Tasks;

class KafkaChatProducer
{
    public static async Task Main(string[] args)
    {
        var config = new ProducerConfig { BootstrapServers = "localhost:9092" };

        using var producer = new ProducerBuilder<Null, string>(config).Build();

        Console.WriteLine("Kafka Chat Producer started. Type messages below:");
        while (true)
        {
            var message = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(message)) break;

            await producer.ProduceAsync("chat-topic", new Message<Null, string> { Value = message });
            Console.WriteLine("Message sent!");
        }
    }
}