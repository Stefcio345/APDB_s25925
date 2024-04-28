namespace Zadanie_4.Repositories;

public interface IOrderRepository
{
    bool OrderExists(int idProduct, int amount, DateTime createdAt);
}