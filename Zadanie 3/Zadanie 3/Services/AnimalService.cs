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
    
    public IEnumerable<IAnimalLike> GetAllAnimals(string orderBy)
    {
        //Logika biznesowa
        var sortableBy = new HashSet<string>() { "name", "description", "category", "area"};

        if (orderBy == "")
        {
            var data = _animalRepository.FetchAnimals("name");
            return data;
        }
        else if (sortableBy.Contains(orderBy.ToLower()))
        {
            var data = _animalRepository.FetchAnimals(orderBy);
            return data;
        }
        else
        {
            throw new ArgumentException("Cannot order by " + orderBy);
        }
    }

    public int CreateAnimal(IAnimalLike newAnimal)
    {
        //Logika biznesowa
        return _animalRepository.CreateAnimal(newAnimal);
    }

    public int UpdateAnimal(int animalId, IAnimalLike animal)
    {
        //Logika biznesowa
        return _animalRepository.UpdateAnimal(animalId, animal);
    }

    public int DeleteAnimal(int idAnimal)
    {
        //Logika biznesowa
        return _animalRepository.DeleteAnimal(idAnimal);
    }
}