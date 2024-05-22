using Microsoft.AspNetCore.Mvc;
using Zadanie_5.Context;

namespace Zadanie_5.Controllers;

[Route("api/clients")]
[ApiController]
public class ClientController: ControllerBase
{
    [Route("{idClient:int}")]
    [HttpDelete]
    public IActionResult deleteClient(int idClient)
    {
        var dbContext = new S25925Context();
        var trips = dbContext.Trips.OrderBy(c => c.DateFrom);
        return Ok(trips);
    }
}