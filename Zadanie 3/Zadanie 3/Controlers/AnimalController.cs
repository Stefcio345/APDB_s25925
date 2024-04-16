using Microsoft.AspNetCore.Mvc;
using Zadanie_3.Models;
using Zadanie_3.Services;

namespace Zadanie_3.Controlers;

[Route("api/animals")]
[ApiController]
public class AnimalController: ControllerBase
{
    private readonly IAnimalService _animalService;

    public AnimalController(IAnimalService animalService)
    {
        _animalService = animalService;
    }

    [HttpGet]
    public IActionResult GetAnimals(string orderBy = "name")
    {
        return Ok(_animalService.GetAllAnimals(orderBy));
    }
    
    [HttpPost]
    public IActionResult AddAnimal(IAnimalLike animal)
    {
        var affectedCount = _animalService.CreateAnimal(animal);
        return StatusCode(StatusCodes.Status201Created);
    }
    
    [HttpPut("{idAnimal:int}")]
    public IActionResult UpdateAnimal(int idAnimal, IAnimalLike animal)
    {
        var affectedCount = _animalService.UpdateAnimal(idAnimal, animal);
        return StatusCode(StatusCodes.Status202Accepted);
    }
    
    [HttpDelete("{idAnimal:int}")]
    public IActionResult DeleteAnimal(int idAnimal)
    {
        var affectedCount = _animalService.DeleteAnimal(idAnimal);
        return StatusCode(StatusCodes.Status202Accepted);
    }
    
}