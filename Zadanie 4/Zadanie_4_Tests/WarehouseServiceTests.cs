using Zadanie_4.Models;
using Zadanie_4.Repositories;
using Zadanie_4.Services;

namespace Zadanie_4_Tests;

public class WarehouseServiceTests
{
    
    private readonly ProductRepository _dummyProductRepository = new ProductRepository(new DummyConfiguration());
    private readonly WarehouseRepository _dummyWarehouseRepository = new WarehouseRepository(new DummyConfiguration());
    private readonly OrderRepository _dummyOrderRepository = new OrderRepository(new DummyConfiguration());
    
    [Fact]
    public void DataIsValid_Should_Return_False_When_Warehouse_Doesnt_Exist()
    {
        AddProduct addProduct = new AddProduct()
        {
            IdProduct = 1,
            IdWarehouse = 1,
            Amount = 125,
            CreatedAt = DateTime.Parse("2024-04-28 16:50:01.440")
        };
        
        var service = new WarehouseService(_dummyProductRepository, _dummyWarehouseRepository, _dummyOrderRepository);

        var result = service.DataIsValid(addProduct);
        
        Assert.Equal(false, result);
    }
}