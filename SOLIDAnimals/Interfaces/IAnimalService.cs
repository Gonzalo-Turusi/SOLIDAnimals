using SOLIDAnimals.Domain;

namespace SOLIDAnimals.Interfaces
{
    // Interface Segregation Principle (ISP)
    // This interface is small and focused, providing only the necessary methods for managing animals.
    public interface IAnimalService
    {
        IEnumerable<Animal> GetAllAnimals();
        void AddAnimal(Animal animal);
        void RemoveAnimal(string animal);
        void ReceiveOwner();
        void GoodbyeToOwner();
    }
}
