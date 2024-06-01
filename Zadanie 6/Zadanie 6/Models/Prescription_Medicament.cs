
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Zadanie_6.Models;

[PrimaryKey(nameof(IdMedicament), nameof(IdPrescription))]
public partial class Prescription_Medicament
{
    
    public int IdMedicament { get; set; }
    [ForeignKey(nameof(IdMedicament))] 
    public Medicament Medicament { get; set; } = null!;
    
    public int IdPrescription { get; set; }
    [ForeignKey(nameof(IdPrescription))] 
    public Prescription Prescription { get; set; } = null!;
    
    public int Dose { get; set; }
    
    [Required]
    [MaxLength(100)]
    public string Details { get; set; }
}