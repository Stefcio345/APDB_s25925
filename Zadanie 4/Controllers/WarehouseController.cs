using System.Net;
using System.Runtime.InteropServices;
using Microsoft.AspNetCore.Mvc;
using Zadanie_4.Models;
using Zadanie_4.Repositories;
using Zadanie_4.Services;

namespace Zadanie_4.Controllers;

[Route("api/warehouse")]
[ApiController]
public class WarehouseController: ControllerBase
{
    private readonly IWarehouseService _warehouseService;

    public WarehouseController(IWarehouseService warehouseService)
    {
        _warehouseService = warehouseService;
    }

    [HttpPost]
    public IActionResult AddProducts(AddProduct addProduct)
    {
        switch (_warehouseService.AddProduct(addProduct))
        {
            case "Error":
                return StatusCode(StatusCodes.Status400BadRequest);
            case "OK":
                return StatusCode(StatusCodes.Status200OK);
            default:
                return StatusCode(StatusCodes.Status400BadRequest); 
        }
    }
}