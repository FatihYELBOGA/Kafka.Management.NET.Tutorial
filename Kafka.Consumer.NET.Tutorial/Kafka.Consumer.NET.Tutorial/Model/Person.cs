namespace Kafka.Producer.NET.Tutorial.Model
{
    public class Person
    {

        public Person(string fullName, string phone)
        {
            FullName = fullName;
            Phone = phone;
        }

        public string FullName { get; set; }
        public string Phone { get; set; }

    }
}
