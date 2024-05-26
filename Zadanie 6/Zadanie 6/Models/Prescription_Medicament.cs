
using System.ComponentModel.DataAnnotations;

namespace Zadanie_6.Models;

public class Prescription_Medicament
{
    [Key]
    public Medicament Medicament { get; set; }
    
    [Key]
    public Prescription Prescription { get; set; }
    
    public int Dose { get; set; }
    
    [Required]
    [MaxLength(100)]
    public string Details { get; set; }
}