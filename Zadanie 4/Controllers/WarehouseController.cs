using System.Net;
using Microsoft.AspNetCore.Mvc;
using Zadanie_4.Models;
using Zadanie_4.Repositories;

namespace Zadanie_4.Controllers;

[Route("api/warehouse")]
[ApiController]
public class WarehouseController: ControllerBase
{
    private readonly IProductRepository _productRepository;
    private readonly IWarehouseRepository _warehouseRepository;

    public WarehouseController(IProductRepository productRepository, IWarehouseRepository warehouseRepository)
    {
        _productRepository = productRepository;
        _warehouseRepository = warehouseRepository;
    }

    [HttpPost]
    public IActionResult AddProducts(AddProduct addProduct)
    {
        if (addProduct.Amount > 0 && _productRepository.ProductExists(addProduct.IdProduct) && _warehouseRepository.WarehouseExists(addProduct.IdWarehouse))
        {
            _productRepository.AddProductsToWarehouse(addProduct);
            return StatusCode(StatusCodes.Status200OK);
        }
        else
        {
            return StatusCode(StatusCodes.Status400BadRequest);
        }
    }
}