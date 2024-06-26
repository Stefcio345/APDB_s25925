using System.Net;
using System.Runtime.InteropServices;
using Microsoft.AspNetCore.Mvc;
using Zadanie_4.Models;
using Zadanie_4.Repositories;
using Zadanie_4.Services;

namespace Zadanie_4.Controllers;

[Route("api")]
[ApiController]
public class WarehouseController: ControllerBase
{
    private readonly IWarehouseService _warehouseService;

    public WarehouseController(IWarehouseService warehouseService)
    {
        _warehouseService = warehouseService;
    }
    [Route("warehouse")]
    [HttpPost]
    public IActionResult AddProducts(AddProduct addProduct)
    {
        var result = _warehouseService.AddProduct(addProduct);
        return result switch
        {
            "Order is already done" => StatusCode(StatusCodes.Status400BadRequest),
            "Data is invalid" => StatusCode(StatusCodes.Status400BadRequest),
            _ => Content("Data inserted successfully, ID of new Product in warehouse: " + result)
        };
    }
    [Route("warehouseProc")]
    [HttpPost]
    public IActionResult AddProductsProc(AddProduct addProduct)
    {
        try
        {
            var result = _warehouseService.ExecuteProcedure(addProduct);
            return Content("Data inserted successfully, ID of new Product in warehouse: " + result);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(StatusCodes.Status400BadRequest);
        }
    }
}