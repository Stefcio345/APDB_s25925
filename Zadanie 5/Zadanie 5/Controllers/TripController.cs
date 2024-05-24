using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Zadanie_5.Context;
using Zadanie_5.Models;

namespace Zadanie_5.Controllers;

[Route("api/trips")]
[ApiController]
public class TripController: ControllerBase
{
    private readonly S25925Context _dbContext;

    public TripController(S25925Context dbContext)
    {
        _dbContext = dbContext;
    }

    [Route("")]
    [HttpGet]
    public IActionResult GetAllTrips()
    {
        var trips = _dbContext.Trips
            .Include(t => t.ClientTrips)
            .Select(t => new
        {
            Name = t.Name,
            Description = t.Description,
            DateFrom = t.DateFrom,
            DateTo = t.DateTo,
            MaxPeople = t.MaxPeople,
            Countries = t.IdCountries.Select(c => c.Name),
            Clients = t.ClientTrips.Select(ct => new
            {
                ct.IdClientNavigation.FirstName, 
                ct.IdClientNavigation.LastName
            })
            //Clients = dbContext.Clients.Where(c => c.IdClient == 7).Select(c => new {c.FirstName, c.LastName})
        }).OrderByDescending(c => c.DateFrom).ToList();
        return Ok(trips);
    }
    
    [Route("{idTrip:int}/clients")]
    [HttpPost]
    public IActionResult AddClientToTrip(int idTrip, AddClientToTrip addClientToTrip)
    {
        if (!ClientWithPeselExist(addClientToTrip.Pesel))
        {
            AddClient(new Client()
            {
                IdClient = _dbContext.Clients.OrderByDescending(c=> c.IdClient).Select(c => c.IdClient).First()+1,
                FirstName = addClientToTrip.FirstName,
                LastName = addClientToTrip.LastName,
                Email = addClientToTrip.LastName,
                Telephone = addClientToTrip.Telephone,
                Pesel = addClientToTrip.Pesel
            });
        }
        
        if (TripExist(addClientToTrip.IdTrip))
        {
            if (!ClientHasTrip(_dbContext.Clients.Where(c=> c.Pesel == addClientToTrip.Pesel).Select(c=> c.IdClient).First(), addClientToTrip.IdTrip))
            {
                _dbContext.ClientTrips.Add(new ClientTrip()
                {
                    IdClient = _dbContext.Clients.Where(c => c.Pesel == addClientToTrip.Pesel).Select(c=> c.IdClient).First(),
                    IdTrip = addClientToTrip.IdTrip,
                    PaymentDate = addClientToTrip.PaymentDate,
                    RegisteredAt = DateTime.Now
                });
                _dbContext.SaveChanges();
                return Ok("Client has been added to trip");
            }
            else
            {
                _dbContext.SaveChanges();
                return ValidationProblem("Client is already assigned to this trip");
            }
        }
        else
        {
            _dbContext.SaveChanges();
            return ValidationProblem("This trip doesn't exist");
        }
        
    }

    private void AddClient(Client client)
    {
        _dbContext.Clients.Add(client);
    }

    private bool ClientWithPeselExist(string pesel)
    {
        return _dbContext.Clients.Any(c => c.Pesel == pesel);
    }

    private bool TripExist(int idTrip)
    {
        return _dbContext.Trips.Any(c => c.IdTrip == idTrip);
    }

    private bool ClientHasTrip(int idClient, int idTrip)
    {
        return _dbContext.ClientTrips.Any(c => c.IdTrip == idTrip && c.IdClient == idClient);
    }

}