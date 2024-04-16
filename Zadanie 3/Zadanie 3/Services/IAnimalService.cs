using Zadanie_3.Models;
namespace Zadanie_3.Services;

public interface IAnimalService
{
    IEnumerable<IAnimalLike> GetAllAnimals(string orderBy);
    int CreateAnimal(IAnimalLike newAnimal);
    int UpdateAnimal(int animalId, IAnimalLike animal);
    int DeleteAnimal(int idAnimal);
}