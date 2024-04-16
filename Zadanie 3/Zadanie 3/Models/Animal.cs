using System.ComponentModel.DataAnnotations;

namespace Zadanie_3.Models;

public class Animal: IAnimalLike
{
    public int IdAnimal { get; set; }
    [Required]
    [MaxLength(200)]
    public string Name { get; set; }
    public string Description { get; set; }
    [Required]
    [MaxLength(200)]
    public string Category { get; set; }
    [Required]
    [MaxLength(200)]
    public string Area { get; set; }
}