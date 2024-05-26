using Microsoft.AspNetCore.Mvc;
using Zadanie_5.Context;

namespace Zadanie_6.Controllers;

[Route("api")]
[ApiController]
public class PrescriptionController: ControllerBase
{
    private readonly S25925Context _dbContext;

    public PrescriptionController(S25925Context dbContext)
    {
        _dbContext = dbContext;
    }

    [Route("Perscription")]
    [HttpGet]
    public IActionResult getPersription()
    {
        return Ok("Git");
    }
}