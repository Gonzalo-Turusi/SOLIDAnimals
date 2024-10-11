using System.Text.Json.Serialization;

namespace SOLIDAnimals.Domain
{
    public abstract class Animal
    {
        public string Name { get; set; }
        public string Species { get; set; }
        public int Age { get; set; }

        protected Animal(string name, string species, int age)
        {
            Name = name;
            Species = species;
            Age = age;
        }
    }
}
