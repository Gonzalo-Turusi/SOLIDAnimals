using Microsoft.AspNetCore.Mvc;
using Moq;
using SOLIDAnimals.Controllers;
using SOLIDAnimals.Domain;
using SOLIDAnimals.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLIDAnimals.Test
{
    [TestClass]
    public class AnimalControllerTests
    {
        private Mock<IAnimalService> _mockAnimalService;
        private AnimalsController _controller;

        [TestInitialize]
        public void Setup()
        {
            _mockAnimalService = new Mock<IAnimalService>();
            _controller = new AnimalsController(_mockAnimalService.Object);
        }

        [TestMethod]
        public void GetAnimals_ShouldReturnAllAnimals()
        {
            // Arrange
            var animals = new List<Animal> { new Dog("Buddy", "Retriver", 3), new Cat("Whiskers", "Persian", 2) };
            _mockAnimalService.Setup(service => service.GetAllAnimals()).Returns(animals);

            // Act
            var result = _controller.GetAnimals();

            // Assert
            Assert.AreEqual(animals, result);
        }

        [TestMethod]
        public void AddBird_ShouldReturnOkResult()
        {
            // Arrange
            var bird = new Bird("Tweety", "hummingbird", 1);

            // Act
            var result = _controller.AddBird(bird) as OkObjectResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("You add a Bird.", result.Value);
        }

        [TestMethod]
        public void DeleteAnimal_ShouldReturnOkResult()
        {
            // Arrange
            var animalName = "Buddy";

            // Act
            var result = _controller.DeleteAnimal(animalName) as OkObjectResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("You have deleted Buddy :(", result.Value);
        }

        [TestMethod]
        public void AddDog_ShouldReturnOkResult()
        {
            // Arrange
            var dog = new Dog("Buddy", "Retriver", 3);

            // Act
            var result = _controller.AddDog(dog) as OkObjectResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("You add a Dog.", result.Value);
        }

        [TestMethod]
        public void AddCat_ShouldReturnOkResult()
        {
            // Arrange
            var cat = new Cat("Whiskers", "Persian", 2);

            // Act
            var result = _controller.AddCat(cat) as OkObjectResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("You add a Cat.", result.Value);
        }

        [TestMethod]
        public void YouGetHome_ShouldReturnOkResult()
        {
            // Act
            var result = _controller.YouGetHome() as OkResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void YouLeaveHome_ShouldReturnOkResult()
        {
            // Act
            var result = _controller.YouLeaveHome() as OkResult;

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
