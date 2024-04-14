using Zadanie_3.Models;
using Zadanie_3.Repositories;

namespace Zadanie_3.Services;

public class AnimalService: IAnimalService
{
    private readonly IAnimalRepository _animalRepository;

    public AnimalService(IAnimalRepository animalRepository)
    {
        _animalRepository = animalRepository;
    }

    //"39:52"
    public IEnumerable<Animal> GetAnimal()
    {
        var data = _animalRepository.FetchAnimals();
        return data;
    }

    public int CreateAnimal(Animal newAnimal)
    {
        //_testAnimal.Add(newAnimal);
        return 1;
    }
}