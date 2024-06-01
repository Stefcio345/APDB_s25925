using Zadanie_6.Models;

namespace Zadanie_6.Services;

public interface IPrescriptionService
{
    public bool PrescriptionIsValid(Prescription prescription);
    public bool CorrectNumberOfMedicaments(IEnumerable<IMedicamentPrescritpion> medicamentPrescription);
}