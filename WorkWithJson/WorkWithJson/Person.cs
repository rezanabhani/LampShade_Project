namespace WorkWithJson
{
    public class Person
    {
        public string Name { get; set; }
        public string Family { get; set; }
        public int Age { get; set; }

        public Person(string name, string family, int age)
        {
            Name = name;
            Family = family;
            Age = age;
        }
    }
}
  