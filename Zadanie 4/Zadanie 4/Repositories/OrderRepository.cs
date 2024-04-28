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

    public Order GetOrder(int idProduct, int amount, DateTime createdAt)
    {
        var con = new SqlConnection(_configuration["ConnectionStrings:DefaultConnection"]);
        con.Open();

        using var cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandText = "SELECT * FROM s25925.\"Order\" WHERE IdProduct = @idProduct AND Amount = @amount AND CreatedAt < @createdAt";
        cmd.Parameters.AddWithValue("@idProduct", idProduct);
        cmd.Parameters.AddWithValue("@amount", amount);
        cmd.Parameters.AddWithValue("@createdAt", createdAt);

        var de = cmd.ExecuteReader();
        var orders = new List<Order>();
        if (de.HasRows)
        {
            de.Read();
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
            con.Close();
            return order;
        }
        else
        {
            con.Close();
            return null;
        }
    }
}