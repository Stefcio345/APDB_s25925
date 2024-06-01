using Zadanie_5.Context;
using Zadanie_6.Models;

namespace Zadanie_6.Services;

public class PatientService: IPatientService
{
    private readonly S25925Context _dbContext;
    
    public PatientService(S25925Context dbContext)
    {
        _dbContext = dbContext;
    }
    public Patient AddPatient(Patient patient)
    {
        var newPatient = _dbContext.Patients.Add(patient);
        _dbContext.SaveChanges();
        return patient;
    }

    public bool PatientExists(int patientId)
    {
        return _dbContext.Patients.Any(p => p.IdPatient == patientId);
    }
}