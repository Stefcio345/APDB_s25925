using Microsoft.AspNetCore.Mvc;
using Zadanie_5.Context;
using Zadanie_6.Models;
using Zadanie_6.Services;

namespace Zadanie_6.Controllers;

[Route("api/prescription")]
[ApiController]
public class PrescriptionController: ControllerBase
{
    private readonly S25925Context _dbContext;
    private readonly IMedicamentService _medicamentService;
    private readonly IPatientService _patientService;
    private readonly IPrescriptionService _prescriptionService;

    public PrescriptionController(S25925Context dbContext, IMedicamentService medicamentService, IPatientService patientService, IPrescriptionService prescriptionService)
    {
        _dbContext = dbContext;
        _medicamentService = medicamentService;
        _patientService = patientService;
        _prescriptionService = prescriptionService;
    }

    [Route("add")]
    [HttpPost]
    public IActionResult AddPerscription(AddPrescription addPrescription)
    {
        Patient patient;
        if(!_patientService.PatientExists(addPrescription.Patient.IdPatient)){
            patient = _patientService.AddPatient(new Patient()
            {
                FirstName = addPrescription.Patient.FirstName,
                LastName = addPrescription.Patient.LastName,
                BirthDate = addPrescription.Patient.BirthDate
            });
        }
        else
        {
            patient = _dbContext.Patients.Single(p => p.IdPatient == addPrescription.Patient.IdPatient);
        }

        Doctor doctor = _dbContext.Doctors.Single(d => d.IdDoctor == addPrescription.Doctor.IdDoctor);

        foreach (var medicament in addPrescription.Medicaments)
        {
            if (!_medicamentService.MedicamentExist(medicament.IdMedicament))
            {
                return ValidationProblem("Medicament: " + medicament.IdMedicament + " Doesn't exist");
            }
        }

        var newPrescription = new Prescription()
        {
            Date = addPrescription.Date,
            DueDate = addPrescription.DueDate,
            Doctor = doctor,
            Patient = patient
        };

        if (_prescriptionService.PrescriptionIsValid(newPrescription) && _prescriptionService.CorrectNumberOfMedicaments(addPrescription.Medicaments))
        {
            // Add Prescription
            _dbContext.Attach(newPrescription);
            _dbContext.SaveChanges();
            foreach (var medicamentPrescritpion in addPrescription.Medicaments)
            {
                _dbContext.PrescriptionMedicaments.Add(new Prescription_Medicament()
                {
                    IdMedicament = medicamentPrescritpion.IdMedicament,
                    IdPrescription = newPrescription.IdPrescription,
                    Dose = medicamentPrescritpion.Dose,
                    Details = medicamentPrescritpion.Description
                });
            }
            // Add medicaments to prescription
            _dbContext.SaveChanges();
            return Ok("Prescription added succesfully");
        }
        else
        {
            return ValidationProblem("Prescription isn't Valid");
        }


    }
}