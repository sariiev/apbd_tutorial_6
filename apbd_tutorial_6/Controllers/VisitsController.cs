using apbd_tutorial_6.Models;
using Microsoft.AspNetCore.Mvc;

namespace apbd_tutorial_6.Controllers;

[ApiController]
[Route("visits")]
public class VisitsController : ControllerBase
{
    public class VisitData
    {
        public string Description { get; }
        public double Price { get; }

        public VisitData(string description, double price)
        {
            Description = description;
            Price = price;
        }
    }
    public static List<Visit> _visits = new List<Visit>
    {
        new Visit(AnimalsController._animals[0], DateTime.Now, "Regular check up", 100.0),
        new Visit(AnimalsController._animals[1], DateTime.UtcNow, "First check up", 50.0)
    };

[HttpGet]
    public IActionResult GetVisits()
    {
        return Ok(_visits);
    }
    
    [HttpGet("animal/{animalId:int}")]
    public IActionResult GetVisitsByAnimalId(int animalId)
    {
        return Ok(_visits.Where(visit => visit.Animal.Id == animalId));
    }

    [HttpPost("animal/{animalId:int}")]
    public IActionResult AddVisit(int animalId, VisitData visitData)
    {
        try
        {
            Animal animal = AnimalsController._animals.Single(animal => animal.Id == animalId);
            Visit visit = new Visit(animal, DateTime.Now, visitData.Description, visitData.Price);
            _visits.Add(visit);
            return Ok(visit);
        }
        catch (InvalidOperationException)
        {
            return NotFound(new { });
        }
    }
}