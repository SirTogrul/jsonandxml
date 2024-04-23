using System.Text.Json;
using System.Xml.Serialization;

namespace json_and_xml
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Person person = new Person()
            {
                Name = "Togrul",
                Age=21
            };
            //var options = new JsonSerializerOptions();
            //options.WriteIndented = true;

            //string Jsonstr = JsonSerializer.Serialize(person, options);
            //Person person1 = JsonSerializer.Deserialize<Person>(person.ToString());
            
            
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Person));
            using (StringWriter Writer = new StringWriter())
            {
                xmlSerializer.Serialize(Writer , person);
                string xmlString = Writer.ToString();
                Console.WriteLine("Serialized XML:");
                Console.WriteLine(xmlString);

                string xml = "<Person><Name>Togrul</Name><Age>21</Age></Person>";
                using (StringReader Reader = new StringReader(xml))
                {
                    Person deserializedPerson = (Person)xmlSerializer.Deserialize(Reader);
                    Console.WriteLine($"Name: {deserializedPerson.Name}, Age: {deserializedPerson.Age}");
                }
            }
        }
    }
}