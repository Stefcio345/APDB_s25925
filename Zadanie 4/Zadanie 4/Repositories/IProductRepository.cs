using Zadanie_4.Models;

namespace Zadanie_4.Repositories;

public interface IProductRepository
{
    Task<Product> getProduct(int idProduct);
}