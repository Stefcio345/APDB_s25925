using System.Data.SqlClient;
using Zadanie_4.Models;

namespace Zadanie_4.Repositories;

public class ProductRepository: IProductRepository
{
    private IConfiguration _configuration;
    
    public ProductRepository(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public async Task<Product> getProduct(int idProduct)
    {
        await using var con = new SqlConnection(_configuration["ConnectionStrings:DefaultConnection"]);
        await con.OpenAsync();

        await using var cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandText = "SELECT * FROM Product WHERE IdProduct = @idProduct";
        cmd.Parameters.AddWithValue("@idProduct", idProduct);

        var de = await cmd.ExecuteReaderAsync();
        
        if (de.HasRows)
        {
            await de.ReadAsync();
            var product = new Product()
            {
                IdProduct = (int)de["IdProduct"],
                Name = de["Name"].ToString(),
                Description = de["Description"].ToString(),
                Price = (decimal)de["Price"]
            };
            return product;
        }
        else
        {
            return null;
        }
    }
}