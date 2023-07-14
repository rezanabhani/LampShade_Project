  
using System.Text.Json.Serialization;
using Newtonsoft.Json;
using WorkWithJson;
using JsonConverter = System.Text.Json.Serialization.JsonConverter;

var data = File.ReadAllText(@"D:\آموزش\Atriya\آموزش سی شارپ\18-Files and json\Source codes\1.json");
//Console.WriteLine(data);

//Person p = JsonConvert.DeserializeObject<Person>(data);
//Console.WriteLine(p.Name);
//Console.WriteLine(p.Family);

//dynamic p = JsonConvert.DeserializeObject(data);

Person p = new Person("Reza", "Nabahni", 21);
var jsonData = JsonConvert.SerializeObject(p);
Console.ReadKey(); 