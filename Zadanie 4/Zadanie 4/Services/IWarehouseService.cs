using System.Text;
using Zadanie_4.Models;

namespace Zadanie_4.Services;

public interface IWarehouseService
{
    public string AddProduct(AddProduct addProduct);
    public string ExecuteProcedure(AddProduct addProduct);
}