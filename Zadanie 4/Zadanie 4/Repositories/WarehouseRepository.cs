using System.Data;
using System.Data.SqlClient;
using Zadanie_4.Models;

namespace Zadanie_4.Repositories;

public class WarehouseRepository: IWarehouseRepository
{
    private IConfiguration _configuration;
    
    public WarehouseRepository(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public async Task<Warehouse> getWarehouse(int idWarehouse)
    {
        var con = new SqlConnection(_configuration["ConnectionStrings:DefaultConnection"]);
        con.Open();

        using var cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandText = "SELECT * FROM Warehouse WHERE IdWarehouse = @idWarehouse";
        cmd.Parameters.AddWithValue("@idWarehouse", idWarehouse);

        var de = cmd.ExecuteReader();
        
        if (de.HasRows)
        {
            de.Read();
            var warehouse = new Warehouse()
            {
                IdWarehouse = (int)de["IdWarehouse"],
                Name = de["Name"].ToString(),
                Address = de["Address"].ToString(),
            };
            con.Close();
            return warehouse;
        }
        else
        {
            return null;
        }
    }

    public async Task<int> ExecuteProcedure(AddProduct addProduct)
    {
        await using var conn = new SqlConnection(_configuration["ConnectionStrings:DefaultConnection"]);
        
        await conn.OpenAsync();
        
        await using var command = new SqlCommand("AddProductToWarehouse", conn) { CommandType = CommandType.StoredProcedure };
        command.Parameters.Add(new SqlParameter("@Amount", addProduct.Amount));
        command.Parameters.Add(new SqlParameter("@IdProduct", addProduct.IdProduct));
        command.Parameters.Add(new SqlParameter("@IdWarehouse", addProduct.IdWarehouse));
        command.Parameters.Add(new SqlParameter("@CreatedAt", addProduct.CreatedAt));
        
        var result = await command.ExecuteScalarAsync();
        return (int)(decimal)result;
    }
}