using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SOLIDAnimals.Domain;
using SOLIDAnimals.Interfaces;
using SOLIDAnimals.Services;

namespace SOLIDAnimals.Tests
{
    [TestClass]
    public class AnimalServiceTests
    {
        private AnimalService _animalService;

        [TestInitialize]
        public void Setup()
        {
            _animalService = new AnimalService();
        }

        // Single Responsibility Principle (SRP)
        // Each test method is responsible for testing one funcionality.

        [TestMethod]
        [ExpectedException(typeof(KeyNotFoundException))]
        public void RemoveAnimal_ShouldThrowException_WhenAnimalNotFound()
        {
            // Arrange
            var animal = new Mock<Animal>("TestAnimal", "TestSpecies", 1).Object;

            // Act
            _animalService.RemoveAnimal(animal);

            // Assert is handled by ExpectedException
        }

        [TestMethod]
        public void RemoveAnimal_ShouldNotThrowException_WhenAnimalFound()
        {
            // Arrange
            var animal = new Mock<Animal>("TestAnimal", "TestSpecies", 1).Object;
            _animalService.AddAnimal(animal);

            // Act & Assert
            try
            {
                _animalService.RemoveAnimal(animal);
            }
            catch (KeyNotFoundException)
            {
                Assert.Fail("Expected no exception, but got KeyNotFoundException");
            }
        }

        [TestMethod]
        public void AddAnimal_ShouldAddAnimalToList()
        {
            // Arrange
            var animal = new Mock<Animal>("TestAnimal", "TestSpecies", 1).Object;

            // Act
            _animalService.AddAnimal(animal);

            // Assert
            var animals = _animalService.GetAllAnimals();
            CollectionAssert.Contains((System.Collections.ICollection)animals, animal);
        }

        [TestMethod]
        public void GetAllAnimals_ShouldReturnAllAnimals()
        {
            // Arrange
            var animal1 = new Mock<Animal>("TestAnimal1", "TestSpecies1", 1).Object;
            var animal2 = new Mock<Animal>("TestAnimal2", "TestSpecies2", 2).Object;
            _animalService.AddAnimal(animal1);
            _animalService.AddAnimal(animal2);

            // Act
            var animals = _animalService.GetAllAnimals();

            // Assert
            CollectionAssert.Contains((System.Collections.ICollection)animals, animal1);
            CollectionAssert.Contains((System.Collections.ICollection)animals, animal2);
        }

        [TestMethod]
        public void YouGetHome_ShouldMakeAnimalSound()
        {
            // Arrange
            var soundAnimal = new Mock<Animal>("TestAnimal", "TestSpecies", 1).As<ISound>();
            soundAnimal.Setup(a => a.MakeSound()).Verifiable();
            _animalService.AddAnimal((Animal)soundAnimal.Object);

            // Act
            _animalService.ReceiveOwner();

            // Assert
            soundAnimal.Verify(a => a.MakeSound(), Times.Once);
        }

        [TestMethod]
        public void YouLeaveHome_ShouldMakeAnimalFly()
        {
            // Arrange
            var flyableAnimal = new Mock<Animal>("TestAnimal", "TestSpecies", 1).As<IFlyable>();
            flyableAnimal.Setup(a => a.Fly()).Verifiable();
            _animalService.AddAnimal((Animal)flyableAnimal.Object);

            // Act
            _animalService.GoodbyeToOwner();

            // Assert
            flyableAnimal.Verify(a => a.Fly(), Times.Once);
        }
    }
}
