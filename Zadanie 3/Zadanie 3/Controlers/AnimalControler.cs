using Microsoft.AspNetCore.Mvc;
using Zadanie_3.Models;
using Zadanie_3.Services;

namespace Zadanie_3.Controlers;

[Route("api/animals")]
[ApiController]
public class AnimalControler: ControllerBase
{
    private readonly IAnimalService _animalService;

    public AnimalControler(IAnimalService animalService)
    {
        _animalService = animalService;
    }

    [HttpGet]
    public IActionResult GetAnimals(string orderBy = "name")
    {
        Console.WriteLine("orderBy");
        return Ok(_animalService.GetAnimal());
    }
    
    [HttpPost]
    public IActionResult AddAnimal(Animal animal)
    {
        _animalService.CreateAnimal(animal);
        return StatusCode(StatusCodes.Status201Created);
    }
    
    [HttpPut("{idAnimal:int}")]
    public IActionResult UpdateAnimal(int idAnimal)
    {
        Console.WriteLine(idAnimal);
        return Ok(_animalService);
    }
    
    [HttpDelete("{idAnimal:int}")]
    public IActionResult DeleteAnimal(int idAnimal)
    {
        Console.WriteLine(idAnimal);
        return Ok(_animalService);
    }
    
}