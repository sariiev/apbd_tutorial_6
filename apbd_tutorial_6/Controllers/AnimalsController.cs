using apbd_tutorial_6.Models;
using Microsoft.AspNetCore.Mvc;

namespace apbd_tutorial_6.Controllers;

[ApiController]
[Route("animals")]
public class AnimalsController : ControllerBase
{
    public static List<Animal> _animals = new List<Animal>
    {
        new Animal("Bob", "Dog", "Red"),
        new Animal("John", "Cat", "Blue")
    };
    
    [HttpGet]
    public IActionResult GetAnimals()
    {
        return Ok(_animals);
    }

    [HttpGet("{id:int}")]
    public IActionResult GetAnimalById(int id)
    {
        try
        {
            return Ok(_animals.Single(animal => animal.Id == id));
        }
        catch (InvalidOperationException)
        {
            return NotFound(new {});
        }
    }

    [HttpPost]
    public IActionResult AddAnimal(Animal newAnimal)
    {
        _animals.Add(newAnimal);
        return Ok(newAnimal);
    }

    [HttpPut("{id:int}")]
    public IActionResult EditAnimal(int id, [FromBody] Animal editedAnimal)
    {
        try
        {
            Animal animalToEdit = _animals.Single(animal => animal.Id == id);
            animalToEdit.Name = editedAnimal.Name;
            animalToEdit.Category = editedAnimal.Category;
            animalToEdit.FurColor = editedAnimal.FurColor;
            return Ok(animalToEdit);
        }
        catch (InvalidOperationException)
        {
            return NotFound(editedAnimal);
        }
    }

    [HttpDelete("{id:int}")]
    public IActionResult DeleteAnimal(int id)
    {
        try
        {
            Animal animalToRemove = _animals.Single(animal => animal.Id == id);
            _animals.Remove(animalToRemove);
            return Ok(animalToRemove);
        }
        catch (InvalidOperationException)
        {
            return NotFound(new { });
        }
    }
}