using SOLIDAnimals.Interfaces;

namespace SOLIDAnimals.Domain
{
    public class Cat : Animal, ISound
    {
        public Cat(string name, string species, int age) : base(name, species, age) { }

        public void MakeSound()
        {
            Console.WriteLine($"{Name} purr with happiness!");
        }
    }
}
