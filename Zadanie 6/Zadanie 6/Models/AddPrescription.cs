namespace Zadanie_6.Models;

public class AddPrescription
{
    public IPatient Patient { get; set; }
    public IDoctor Doctor { get; set; }
    public ICollection<IMedicamentPrescritpion> Medicaments { get; set; }
    public DateTime Date { get; set; }
    public DateTime DueDate { get; set; }
}