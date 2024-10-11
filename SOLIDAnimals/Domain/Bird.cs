using SOLIDAnimals.Interfaces;

namespace SOLIDAnimals.Domain
{
    public class Bird : Animal, IFlyable, ISound
    {
        public Bird(string name, string species, int age) : base(name, species, age) { }

        public void Fly()
        {
            Console.WriteLine($"{Name} flies to see you leave!");
        }

        public void MakeSound()
        {
            Console.WriteLine($"{Name} chirps with happiness!");
        }
    }

}
