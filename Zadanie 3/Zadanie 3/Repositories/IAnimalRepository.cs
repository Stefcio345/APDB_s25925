using Zadanie_3.Models;

namespace Zadanie_3.Repositories;

public interface IAnimalRepository
{
    IEnumerable<IAnimalLike> FetchAnimals(string orderBy);
    int CreateAnimal(IAnimalLike animal);
    int UpdateAnimal(int animalId ,IAnimalLike animal);
    int DeleteAnimal(int animalId);
}