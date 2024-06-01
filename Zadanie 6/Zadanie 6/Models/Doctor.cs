using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;

namespace Zadanie_6.Models;

public partial class Doctor: IDoctor
{
    [Key]
    public int IdDoctor { get; set; }
    
    [Required]
    [MaxLength(100)]
    public string FirstName { get; set; }
    
    [Required]
    [MaxLength(100)]
    public string LastName { get; set; }
    
    [Required]
    [MaxLength(100)]
    public string Email { get; set; }
    
    public virtual ICollection<Prescription> Prescriptions { get; set; } = new List<Prescription>();
}