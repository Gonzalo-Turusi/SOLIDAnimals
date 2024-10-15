using SOLIDAnimals.Domain;
using SOLIDAnimals.Interfaces;

namespace SOLIDAnimals.Services
{
    // Open/Closed Principle (OCP)
    // This class is open for extension (by adding new methods or overriding existing ones in derived classes)
    // but closed for modification (existing code does not need to be changed to add new functionality).
    public class AnimalService : IAnimalService
    {
        private readonly List<Animal> _animals = new List<Animal>();

        // Single Responsibility Principle (SRP)
        // This each method is responsible for only one task.
        public IEnumerable<Animal> GetAllAnimals()
        {
            return _animals;
        }

        public void AddAnimal(Animal animal)
        {
            _animals.Add(animal);
        }

        public void RemoveAnimal(string name)
        {
            var animal = _animals.FirstOrDefault(a => a.Name == name) ?? throw new KeyNotFoundException(name + " not found");
            _animals.Remove(animal);
        }

        // Liskov Substitution Principle (LSP)
        // We can use ISound interface here, which means any class that implements ISound can be used.
        public void ReceiveOwner()
        {
            Console.WriteLine("You get home!");
            foreach (var animal in _animals)
            {
                MakeAnimalSound(animal);
            }
        }

        // Liskov Substitution Principle (LSP)
        // We can use IFlyable interface here, which means any class that implements IFlyable can be used.
        public void GoodbyeToOwner()
        {
            Console.WriteLine("You are leaving home!");
            foreach (var animal in _animals)
            {
                MakeAnimalFly(animal);
            }
        }

        private void MakeAnimalSound(Animal animal)
        {
            if (animal is ISound soundAnimal)
            {
                soundAnimal.MakeSound();
            }
        }

        private void MakeAnimalFly(Animal animal)
        {
            if (animal is IFlyable flyableAnimal)
            {
                flyableAnimal.Fly();
            }
        }
    }
}