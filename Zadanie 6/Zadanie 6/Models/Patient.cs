using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata.Ecma335;

namespace Zadanie_6.Models;

public partial class Patient: IPatient
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
    public virtual ICollection<Prescription> Prescriptions { get; set; } = new List<Prescription>();
}