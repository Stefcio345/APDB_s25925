using System.ComponentModel.DataAnnotations;

namespace Zadanie_6.Models;

public class Prescription
{
    [Key]
    public int IdPrescription { get; set; }

    [Required]
    public DateTime Date { get; set; }
    
    [Required]
    public DateTime DueDate { get; set; }

    public Doctor Doctor { get; set; }
    
    public Patient Patient { get; set; }

    public ICollection<Prescription_Medicament> PrescriptionMedicaments { get; set; }
}