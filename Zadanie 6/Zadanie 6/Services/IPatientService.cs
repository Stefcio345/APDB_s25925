using Zadanie_6.Models;

namespace Zadanie_6.Services;

public interface IPatientService
{
    public Patient AddPatient(Patient patient);
    public bool PatientExists(int patientId);
}