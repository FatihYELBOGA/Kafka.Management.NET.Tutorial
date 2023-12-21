using Confluent.Kafka;
using Kafka.Producer.NET.Tutorial.Model;
using Newtonsoft.Json;

var config = new ConsumerConfig
{
    GroupId = "notification-consumer-group",
    BootstrapServers = "localhost:9092",
    AutoOffsetReset = AutoOffsetReset.Earliest
};

using var consumer = new ConsumerBuilder<Null, string>(config).Build();
consumer.Subscribe("notification-topic");
CancellationTokenSource token = new();

try
{
    while (true)
    {
        var response = consumer.Consume(token.Token);
        if(response.Message != null)
        {
            var person = JsonConvert.DeserializeObject<Person>(response.Message.Value);
            Console.WriteLine($"\nFull name: {person.FullName}, phone number: {person.Phone}");
        }
    }
}
catch(Exception exception)
{
    Console.Write($"Error message: {exception.Message}");
}