using Zadanie_4.Models;

namespace Zadanie_4.Repositories;

public interface IWarehouseRepository
{
    Task<Warehouse> getWarehouse(int idWarehouse);
    public Task<int> ExecuteProcedure(AddProduct addProduct);
}