using System.Data.SqlClient;
using Zadanie_3.Models;

namespace Zadanie_3.Repositories;

public class AnimalRepository: IAnimalRepository
{
    private static readonly List<Animal> _animals = new()
    {
        new Animal {IdAnimal = 1, Area = "Afryka", Category = "Żółte", Description = "Ma długą szyję", Name = "Żyrafa"},
        new Animal {IdAnimal = 2, Area = "Europa", Category = "Brązowe", Description = "Jest dziki", Name = "Dzik"},
        new Animal {IdAnimal = 3, Area = "Ameryka", Category = "Szare", Description = "Mruczy", Name = "Kot"},
    };

    public IEnumerable<Animal> FetchAnimals()
    {
        return _animals;
    }

    public int CreateAnimal(Animal animal)
    {
        throw new NotImplementedException();
    }

    public Animal GetAnimal(int animalId)
    {
        var con = new SqlConnection("Server=db-mssql16.pjwstk.edu.pl;Database=s25925;User Id=s25925;Password=password");
        throw new NotImplementedException();
    }

    public int UpdateAnimal(Animal animal)
    {
        throw new NotImplementedException();
    }

    public int DeleteAnimal(int animalId)
    {
        throw new NotImplementedException();
    }
}