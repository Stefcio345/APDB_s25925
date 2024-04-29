using Zadanie_4.Models;

namespace Zadanie_4.Repositories;

public interface IProduct_WarehouseRepository
{
    public Task<Product_Warehouse> GetProduct_Warehouse(int idOrder);
    public Task<int> AddProductWarehouse(Product_Warehouse productWarehouse);
}