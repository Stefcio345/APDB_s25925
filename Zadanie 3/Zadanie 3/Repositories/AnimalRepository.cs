using System.Data.SqlClient;
using Zadanie_3.Models;

namespace Zadanie_3.Repositories;

public class AnimalRepository: IAnimalRepository
{

    private IConfiguration _configuration;

    public AnimalRepository(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public IEnumerable<IAnimalLike> FetchAnimals(string orderBy)
    {
        var con = new SqlConnection(_configuration["ConnectionStrings:DefaultConnection"]);
        con.Open();

        using var cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandText = "SELECT * FROM Animals ORDER BY " + orderBy + " ASC";

        var de = cmd.ExecuteReader();
        var animals = new List<Animal>();
        while (de.Read())
        {
            var an = new Animal()
            {
                IdAnimal = (int)de["IdAnimal"],
                Area = de["Area"].ToString(),
                Category = de["Category"].ToString(),
                Description = de["Description"].ToString(),
                Name = de["Name"].ToString()
            };
            animals.Add(an);
        }
            
        con.Close();
        
        return animals;
    }

    public int CreateAnimal(IAnimalLike animal)
    {
        using var con = new SqlConnection(_configuration["ConnectionStrings:DefaultConnection"]);
        con.Open();
        
        using var cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandText = "INSERT INTO Animals VALUES(@Name, @Description, @Category, @Area)";
        //cmd.Parameters.AddWithValue("@IdAnimal", animal.IdAnimal);
        cmd.Parameters.AddWithValue("@Name", animal.Name);
        cmd.Parameters.AddWithValue("@Description", animal.Description);
        cmd.Parameters.AddWithValue("@Category", animal.Category);
        cmd.Parameters.AddWithValue("@Area", animal.Area);
        
        var affectedCount = cmd.ExecuteNonQuery();
        return affectedCount;
    }

    public int UpdateAnimal(int animalId, IAnimalLike animal)
    {
        using var con = new SqlConnection(_configuration["ConnectionStrings:DefaultConnection"]);
        con.Open();
        
        using var cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandText = "UPDATE Animals SET Name = @Name, Description = @Description, Category = @Category, Area = @Area WHERE IdAnimal = @IdAnimal";
        cmd.Parameters.AddWithValue("@IdAnimal", animalId);
        cmd.Parameters.AddWithValue("@Name", animal.Name);
        cmd.Parameters.AddWithValue("@Description", animal.Description);
        cmd.Parameters.AddWithValue("@Category", animal.Category);
        cmd.Parameters.AddWithValue("@Area", animal.Area);
        
        var affectedCount = cmd.ExecuteNonQuery();
        return affectedCount;
    }

    public int DeleteAnimal(int animalId)
    {
        using var con = new SqlConnection(_configuration["ConnectionStrings:DefaultConnection"]);
        con.Open();
        
        using var cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandText = "DELETE FROM Animals WHERE IdAnimal = @IdStudent";
        //cmd.Parameters.AddWithValue("@IdAnimal", animal.IdAnimal);
        cmd.Parameters.AddWithValue("@IdStudent", animalId);
        
        var affectedCount = cmd.ExecuteNonQuery();
        return affectedCount;
    }
}