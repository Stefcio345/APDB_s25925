using Zadanie_4.Models;
using Zadanie_4.Repositories;

namespace Zadanie_4.Services;

public class WarehouseService: IWarehouseService
{
    private readonly IProductRepository _productRepository;
    private readonly IWarehouseRepository _warehouseRepository;
    private readonly IOrderRepository _orderRepository;
    private readonly IProduct_WarehouseRepository _productWarehouseRepository;

    public WarehouseService(IProductRepository productRepository, IWarehouseRepository warehouseRepository, IOrderRepository orderRepository, IProduct_WarehouseRepository productWarehouseRepository)
    {
        _productRepository = productRepository;
        _warehouseRepository = warehouseRepository;
        _orderRepository = orderRepository;
        _productWarehouseRepository = productWarehouseRepository;
    }

    public string ExecuteProcedure(AddProduct addProduct)
    {
        var result = _warehouseRepository.ExecuteProcedure(addProduct);
        return result.Result.ToString();
    }

    public string AddProduct(AddProduct addProduct)
    {
        //1. i 2.
        if (DataIsValid(addProduct) && OrderIsValid(addProduct))
        {
            //3.
            //Get order
            var order = _orderRepository.GetOrder(addProduct.IdProduct, addProduct.Amount, addProduct.CreatedAt).Result;
            if (OrderWasAlreadyDone(order))
            {
                return "Order is already done";
            }
            else
            {
                //4.
                _orderRepository.UpdateFullfilled(order.IdOrder);
                //5.
                var insertedId = _productWarehouseRepository.AddProductWarehouse(CreateProductWarehouse(addProduct, order)).Result;
                
                return insertedId.ToString();
            }
        }
        else
        {
            return "Data is invalid";
        }
    }

    public bool DataIsValid(AddProduct addProduct)
    {
        //Does product exist
        if (_productRepository.getProduct(addProduct.IdProduct).Result is null)
        {
            return false;
        }
        //Does warehouse exist
        else if (_warehouseRepository.getWarehouse(addProduct.IdWarehouse).Result is null)
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
        var order = _orderRepository.GetOrder(addProduct.IdProduct, addProduct.Amount, addProduct.CreatedAt).Result;
        return order is not null;
    }

    public bool OrderWasAlreadyDone(Order order)
    {
        return _productWarehouseRepository.GetProduct_Warehouse(order.IdOrder).Result is not null;
    }

    public Product_Warehouse CreateProductWarehouse(AddProduct addProduct, Order order)
    {
        return new Product_Warehouse()
        {
            IdProductWarehouse = null,
            IdWarehouse = addProduct.IdWarehouse,
            IdProduct = addProduct.IdProduct,
            IdOrder = order.IdOrder,
            Amount = addProduct.Amount,
            Price = _productRepository.getProduct(addProduct.IdProduct).Result.Price * addProduct.Amount,
            CreatedAt = DateTime.Now
        };
    }
}