using Zadanie_4.Models;

namespace Zadanie_4.Repositories;

public interface IProductRepository
{
    Product getProduct(int idProduct);
}