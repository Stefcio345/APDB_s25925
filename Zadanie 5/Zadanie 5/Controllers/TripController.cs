using Microsoft.AspNetCore.Mvc;
using Zadanie_5.Context;
using Zadanie_5.Models;

namespace Zadanie_5.Controllers;

[Route("api/trips")]
[ApiController]
public class TripController: ControllerBase
{
    [Route("")]
    [HttpGet]
    public IActionResult GetAllTrips()
    {
        var dbContext = new S25925Context();
        var trips = dbContext.Trips.OrderByDescending(c => c.DateFrom);
        return Ok(trips);
    }
    
    [Route("{idTrip:int}/clients")]
    [HttpPost]
    public IActionResult AddClientToTrip(int idTrip, AddClientToTrip addClientToTrip)
    {
        var dbContext = new S25925Context();
        var trips = dbContext.Trips.OrderBy(c => c.DateFrom);
        return Ok(trips);
    }
}