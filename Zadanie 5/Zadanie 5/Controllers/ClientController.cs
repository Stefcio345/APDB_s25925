using Microsoft.AspNetCore.Mvc;
using Zadanie_5.Context;
using Zadanie_5.Models;

namespace Zadanie_5.Controllers;

[Route("api/clients")]
[ApiController]
public class ClientController: ControllerBase
{
    private readonly S25925Context _dbContext;

    public ClientController(S25925Context dbContext)
    {
        _dbContext = dbContext;
    }
    
    [Route("{idClient:int}")]
    [HttpDelete]
    public IActionResult deleteClient(int idClient)
    {
        var numberOfTrips = _dbContext.Clients.Where(c => c.IdClient == idClient).Select(c => c.ClientTrips.Select(ct => ct.IdTripNavigation.IdTrip).Count()).First();
        
        if (numberOfTrips == 0)
        {
            var client = _dbContext.Clients.First(c => c.IdClient == idClient);
            _dbContext.Clients.Remove(client);
            _dbContext.SaveChanges();
            return Ok("The client has been removed");
        }
        else
        {
            return ValidationProblem("The client still has trips in database");
        }
    }
}