using Confluent.Kafka;
using Newtonsoft.Json;
using Kafka.Producer.NET.Tutorial.Model;

var config = new ProducerConfig { BootstrapServers = "localhost:9092" };
using var producer = new ProducerBuilder<Null, string>(config).Build();

try
{
    while (true)
    {
        Console.Write("Please enter the full name: ");
        string fullName = Console.ReadLine();

        Console.Write("Please enter the phone number: ");
        string phone = Console.ReadLine();

        var response = await producer.ProduceAsync("notification-topic", new Message<Null, string>
        {
            Value = JsonConvert.SerializeObject(new Person(fullName, phone))
        });
        Console.WriteLine($"\nFull name: {fullName}, phone number: {phone}");
        Console.WriteLine("------------------------------");
    }
} 
catch(ProduceException<Null, string> exception)
{
    Console.Write($"Error message: {exception.Message}");
}