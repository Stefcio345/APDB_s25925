using Zadanie_4.Models;

namespace Zadanie_4.Repositories;

public interface IProduct_WarehouseRepository
{
    public Product_Warehouse GetProduct_Warehouse(int idOrder);
    public int AddProductWarehouse(Product_Warehouse productWarehouse);
}