using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Zadanie_5.Context;
using Zadanie_6.Models;

namespace Zadanie_6.Controllers;

[Route("api/patient")]
[ApiController]
public class PatientController: ControllerBase
{
    private readonly S25925Context _dbContext;

    public PatientController(S25925Context dbContext)
    {
        _dbContext = dbContext;
    }

    [Route("view/{patientId:int}")]
    [HttpGet]
    public IActionResult View(int patientId)
    {
        var response = _dbContext.Patients
            .Where(p => p.IdPatient == patientId)
            .Select(patient => new
        {
            IdPatient = patient.IdPatient,
            FirstName = patient.FirstName,
            LastName = patient.LastName,
            Birthday = patient.BirthDate,
            Prescriptions = patient.Prescriptions.OrderBy(pre => pre.DueDate).Select( prescription => new
            {
                IdPrescritpion = prescription.IdPrescription,
                Date = prescription.Date,
                DueDate = prescription.DueDate,
                Medicaments = prescription.PrescriptionMedicaments.Select(pm => new
                {
                    IdMedicament = pm.Medicament.IdMedicament,
                    Name = pm.Medicament.Name,
                    Dose = pm.Dose,
                    Description = pm.Medicament.Description
                }),
                Doctor = new {IdDoctor = prescription.Doctor.IdDoctor, FirstName = prescription.Doctor.FirstName}
            })
        }).ToList();
        return Ok(response);
    }
}