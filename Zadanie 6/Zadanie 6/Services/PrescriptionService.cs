using Zadanie_6.Models;

namespace Zadanie_6.Services;

public class PrescriptionService: IPrescriptionService
{
    public bool PrescriptionIsValid(Prescription prescription)
    {
        return prescription.Date <= prescription.DueDate;
    }

    public bool CorrectNumberOfMedicaments(IEnumerable<IMedicamentPrescritpion> medicamentPrescription)
    {
        return medicamentPrescription.Count() <= 10;
    }
}