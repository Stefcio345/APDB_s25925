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
    public int AddProductsToWarehouse(AddProduct addProduct)
    {
        throw new NotImplementedException();
    }

    public Product getProduct(int idProduct)
    {
        var con = new SqlConnection(_configuration["ConnectionStrings:DefaultConnection"]);
        con.Open();

        using var cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandText = "SELECT * FROM Product WHERE IdProduct = @idProduct";
        cmd.Parameters.AddWithValue("@idProduct", idProduct);

        var de = cmd.ExecuteReader();
        
        if (de.HasRows)
        {
            de.Read();
            var product = new Product()
            {
                IdProduct = (int)de["IdProduct"],
                Name = de["Name"].ToString(),
                Description = de["Description"].ToString(),
                Price = (decimal)de["Price"]
            };
            con.Close();
            return product;
        }
        else
        {
            return null;
        }
    }
    
    public bool ProductExists(int idProduct)
    {
        var con = new SqlConnection(_configuration["ConnectionStrings:DefaultConnection"]);
        con.Open();
        
        using var cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandText = "SELECT COUNT(1) AS BOOL FROM s25925.Product WHERE IdProduct = @IdWarehouse";
        cmd.Parameters.AddWithValue("@IdWarehouse", idProduct);
        var de = cmd.ExecuteReader();
        de.Read();
        return (int)de["BOOL"] == 1;
        
    }
}