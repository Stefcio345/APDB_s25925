using System.Data.SqlClient;
using Zadanie_4.Models;

namespace Zadanie_4.Repositories;

public class Product_WarehouseRepository: IProduct_WarehouseRepository
{
    private IConfiguration _configuration;
    
    public Product_WarehouseRepository(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    
    public async Task<Product_Warehouse> GetProduct_Warehouse(int idOrder)
    {
        await using var con = new SqlConnection(_configuration["ConnectionStrings:DefaultConnection"]);
        await con.OpenAsync();

        await using var cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandText = "SELECT * FROM s25925.Product_Warehouse WHERE IdOrder = @IdOrder";
        cmd.Parameters.AddWithValue("@idOrder", idOrder);

        var de = await cmd.ExecuteReaderAsync();
        if (de.HasRows)
        {
            await de.ReadAsync();
            var order = new Product_Warehouse()
            {
                IdProductWarehouse = (int)de["IdProductWarehouse"],
                IdWarehouse = (int)de["IdWarehouse"],
                IdProduct = (int)de["IdProduct"],
                IdOrder = (int)de["IdOrder"],
                Amount = (int)de["Amount"],
                Price = (decimal)de["Price"],
                CreatedAt = DateTime.Parse(de["CreatedAt"].ToString()),
            };
            return order;
        }
        else
        {
            return null;
        }
    }
    
    public async Task<int> AddProductWarehouse(Product_Warehouse productWarehouse)
    {
        await using var con = new SqlConnection(_configuration["ConnectionStrings:DefaultConnection"]);
        await con.OpenAsync();

        await using var cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandText = "INSERT INTO s25925.Product_Warehouse OUTPUT inserted.IdProductWarehouse VALUES(@IdWarehouse, @IdProduct, @IdOrder, @Amount, @Price, @Now);";
        cmd.Parameters.AddWithValue("@IdWarehouse", productWarehouse.IdWarehouse);
        cmd.Parameters.AddWithValue("@IdProduct", productWarehouse.IdProduct);
        cmd.Parameters.AddWithValue("@IdOrder", productWarehouse.IdOrder);
        cmd.Parameters.AddWithValue("@Amount", productWarehouse.Amount);
        cmd.Parameters.AddWithValue("@Price", productWarehouse.Price);
        cmd.Parameters.AddWithValue("@Now", DateTime.Now);

        var insertedId = await cmd.ExecuteScalarAsync();
        return (int)insertedId;
    }
}