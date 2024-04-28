using Zadanie_4.Models;

namespace Zadanie_4.Repositories;

public interface IOrderRepository
{
    public Order GetOrder(int idProduct, int amount, DateTime createdAt);
}