using System.Data.SqlClient;

namespace Zadanie_4.Repositories;

public class WarehouseRepository: IWarehouseRepository
{
    private IConfiguration _configuration;
    
    public WarehouseRepository(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    public bool WarehouseExists(int idWarehouse)
    {
        var con = new SqlConnection(_configuration["ConnectionStrings:DefaultConnection"]);
        con.Open();
        
        using var cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandText = "SELECT COUNT(1) AS BOOL FROM s25925.Warehouse WHERE IdWarehouse = @IdWarehouse";
        cmd.Parameters.AddWithValue("@IdWarehouse", idWarehouse);
        var de = cmd.ExecuteReader();
        de.Read();
        return (int)de["BOOL"] == 1;
    }
}