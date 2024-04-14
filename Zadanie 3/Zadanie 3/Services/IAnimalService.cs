using Zadanie_3.Models;
namespace Zadanie_3.Services;

public interface IAnimalService
{
    IEnumerable<Animal> GetAnimal();
    int CreateAnimal(Animal newAnimal);
}