using System.Data.SqlClient;
using Zadanie_4.Models;

namespace Zadanie_4.Repositories;

public class OrderRepository: IOrderRepository
{
    private IConfiguration _configuration;
    
    public OrderRepository(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public async Task<Order> GetOrder(int idProduct, int amount, DateTime createdAt)
    {
        await using var con = new SqlConnection(_configuration["ConnectionStrings:DefaultConnection"]);
        await con.OpenAsync();

        await using var cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandText = "SELECT * FROM s25925.\"Order\" WHERE IdProduct = @idProduct AND Amount = @amount AND CreatedAt < @createdAt";
        cmd.Parameters.AddWithValue("@idProduct", idProduct);
        cmd.Parameters.AddWithValue("@amount", amount);
        cmd.Parameters.AddWithValue("@createdAt", createdAt);

        var de = await cmd.ExecuteReaderAsync();
        if (de.HasRows)
        {
            await de.ReadAsync();
            DateTime? fulfilledAt =
                String.IsNullOrEmpty(de["FulfilledAt"].ToString()) ? null : DateTime.Parse(de["FulfilledAt"].ToString() ?? string.Empty);
            var order = new Order()
            {
                IdOrder = (int)de["IdOrder"],
                IdProduct = (int)de["IdProduct"],
                Amount = (int)de["Amount"],
                CreatedAt = DateTime.Parse(de["CreatedAt"].ToString()),
                FulfilledAt = fulfilledAt
            };
            return order;
        }
        else
        {
            return null;
        }
    }
    
    public async Task<int> UpdateFullfilled(int idOrder)
    {
        await using var con = new SqlConnection(_configuration["ConnectionStrings:DefaultConnection"]);
        await con.OpenAsync();

        await using var cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandText = "UPDATE s25925.\"Order\" SET FulfilledAt = @now WHERE IdOrder = @idOrder";
        cmd.Parameters.AddWithValue("@idOrder", idOrder);
        cmd.Parameters.AddWithValue("@now", DateTime.Now);

        var affectedCount = await cmd.ExecuteNonQueryAsync();
        return affectedCount;
    }
}