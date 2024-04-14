using Zadanie_3.Models;

namespace Zadanie_3.Repositories;

public interface IAnimalRepository
{
    IEnumerable<Animal> FetchAnimals();
    int CreateAnimal(Animal animal);
    Animal GetAnimal(int animalId);
    int UpdateAnimal(Animal animal);
    int DeleteAnimal(int animalId);

}