using Zadanie_4.Models;

namespace Zadanie_4.Repositories;

public interface IProductRepository
{
    int AddProductsToWarehouse(AddProduct addProduct);
    Product getProduct(int idProduct);
}