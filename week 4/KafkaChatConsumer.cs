using Confluent.Kafka;
using System;
using System.Threading;

class KafkaChatConsumer
{
    public static void Main(string[] args)
    {
        var config = new ConsumerConfig
        {
            GroupId = "chat-group",
            BootstrapServers = "localhost:9092",
            AutoOffsetReset = AutoOffsetReset.Earliest
        };

        using var consumer = new ConsumerBuilder<Ignore, string>(config).Build();
        consumer.Subscribe("chat-topic");

        Console.WriteLine("Kafka Chat Consumer started. Listening for messages...");
        while (true)
        {
            var cr = consumer.Consume(CancellationToken.None);
            Console.WriteLine($"Received: {cr.Message.Value}");
        }
    }
}