using Zadanie_4.Models;

namespace Zadanie_4.Repositories;

public interface IWarehouseRepository
{
    Warehouse getWarehouse(int idWarehouse);
    public bool WarehouseExists(int idWarehouse);
}