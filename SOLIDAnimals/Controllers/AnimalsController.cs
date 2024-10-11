using Microsoft.AspNetCore.Mvc;
using SOLIDAnimals.Domain;
using SOLIDAnimals.Interfaces;

namespace SOLIDAnimals.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnimalsController : ControllerBase
    {
        private readonly IAnimalService _animalService;

        // Dependency Inversion Principle (DIP)
        // The controller depends on the IAnimalService abstraction rather than a concrete implementation.
        public AnimalsController(IAnimalService animalService)
        {
            _animalService = animalService;
        }

        // GET: api/animals
        [HttpGet]
        public IEnumerable<Animal> GetAnimals()
        {
            return _animalService.GetAllAnimals();
        }

        // POST: api/animals/
        [HttpPost("AddBird")]
        public IActionResult AddBird([FromBody] Bird animal)
        {
            _animalService.AddAnimal(animal);
            return Ok("You add a Bird.");
        }

        // POST: api/animals/
        [HttpPost("AddDog")]
        public IActionResult AddDog([FromBody] Dog animal)
        {
            _animalService.AddAnimal(animal);
            return Ok("You add a Dog.");
        }

        // POST: api/animals/
        [HttpPost("AddCat")]
        public IActionResult AddCat([FromBody] Cat animal)
        {
            _animalService.AddAnimal(animal);
            return Ok("You add a Cat.");
        }

        // POST: api/animals/
        [HttpDelete()]
        public IActionResult DeleteAnimal([FromBody] Animal animal)
        {
            _animalService.RemoveAnimal(animal);
            return Ok("You delete this animal :(");
        }

        [HttpPut("YouGetHome")]
        public IActionResult YouGetHome()
        {
            _animalService.ReceiveOwner();
            return Ok();
        }

        [HttpPut("YouLeaveHome")]
        public IActionResult YouLeaveHome()
        {
            _animalService.GoodbyeToOwner();
            return Ok();
        }
    }
}
