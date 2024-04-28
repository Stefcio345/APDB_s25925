using Zadanie_4.Models;
using Zadanie_4.Repositories;

namespace Zadanie_4.Services;

public class WarehouseService: IWarehouseService
{
    private readonly IProductRepository _productRepository;
    private readonly IWarehouseRepository _warehouseRepository;
    private readonly IOrderRepository _orderRepository;

    public WarehouseService(IProductRepository productRepository, IWarehouseRepository warehouseRepository, IOrderRepository orderRepository)
    {
        _productRepository = productRepository;
        _warehouseRepository = warehouseRepository;
        _orderRepository = orderRepository;
    }

    public string AddProduct(AddProduct addProduct)
    {
        if (DataIsValid(addProduct) && OrderIsValid(addProduct))
        {
            _productRepository.AddProductsToWarehouse(addProduct);
            return "OK";
        }
        else
        {
            return "Error";
        }
    }

    public bool DataIsValid(AddProduct addProduct)
    {
        //Does product exist
        if (!_productRepository.ProductExists(addProduct.IdProduct))
        {
            return false;
        }
        //Does warehouse exist
        else if (!_warehouseRepository.WarehouseExists(addProduct.IdWarehouse))
        {
            return false;
        }
        //Is amount less or equal to 0
        else if (addProduct.Amount <= 0)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    public bool OrderIsValid(AddProduct addProduct)
    {
        return _orderRepository.OrderIsValid(addProduct.IdProduct, addProduct.Amount, addProduct.CreatedAt);
    }
}