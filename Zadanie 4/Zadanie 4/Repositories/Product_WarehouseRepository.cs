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
    
    public Product_Warehouse GetProduct_Warehouse(int idOrder)
    {
        var con = new SqlConnection(_configuration["ConnectionStrings:DefaultConnection"]);
        con.Open();

        using var cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandText = "SELECT * FROM s25925.Product_Warehouse WHERE IdOrder = @IdOrder";
        cmd.Parameters.AddWithValue("@idOrder", idOrder);

        var de = cmd.ExecuteReader();
        if (de.HasRows)
        {
            de.Read();
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
            con.Close();
            return order;
        }
        else
        {
            con.Close();
            return null;
        }
    }
    
    public int AddProductWarehouse(Product_Warehouse productWarehouse)
    {
        var con = new SqlConnection(_configuration["ConnectionStrings:DefaultConnection"]);
        con.Open();

        using var cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandText = "INSERT INTO s25925.Product_Warehouse OUTPUT inserted.IdProductWarehouse VALUES(@IdWarehouse, @IdProduct, @IdOrder, @Amount, @Price, @Now);";
        cmd.Parameters.AddWithValue("@IdWarehouse", productWarehouse.IdWarehouse);
        cmd.Parameters.AddWithValue("@IdProduct", productWarehouse.IdProduct);
        cmd.Parameters.AddWithValue("@IdOrder", productWarehouse.IdOrder);
        cmd.Parameters.AddWithValue("@Amount", productWarehouse.Amount);
        cmd.Parameters.AddWithValue("@Price", productWarehouse.Price);
        cmd.Parameters.AddWithValue("@Now", DateTime.Now);

        var insertedId = (int)cmd.ExecuteScalar();
        return insertedId;
    }
}