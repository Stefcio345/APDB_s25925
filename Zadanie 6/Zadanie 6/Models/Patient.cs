using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata.Ecma335;

namespace Zadanie_6.Models;

public class Patient
{
    [Key]
    public int IdPatient { get; set; }
    
    [Required]
    [MaxLength(100)]
    public string FirstName { get; set; }
    
    [Required]
    [MaxLength(100)]
    public string LastName { get; set; }
    
    [Required]
    public DateTime BirthDate { get; set; }

    public ICollection<Prescription> Prescriptions { get; set; }
}