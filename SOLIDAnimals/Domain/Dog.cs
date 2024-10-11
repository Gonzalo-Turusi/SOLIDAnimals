using SOLIDAnimals.Interfaces;

namespace SOLIDAnimals.Domain
{
    public class Dog : Animal, ISound
    {
        public Dog(string name, string species, int age) : base(name, species, age) { }

        public void MakeSound()
        {
            Console.WriteLine($"{Name} barks of happiness!");
        }
    }

}
