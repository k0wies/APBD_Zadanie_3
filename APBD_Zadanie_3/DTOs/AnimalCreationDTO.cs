using System.ComponentModel.DataAnnotations;

namespace APBD_Zadanie_3.DTOs;

public class AnimalCreationDTO
{
    [Required(ErrorMessage = "The name field is required.")]
    public string Name { get; set; }

    [Required(ErrorMessage = "The description field is required.")]
    public string Description { get; set; }

    public string Category { get; set; }

    public string Area { get; set; }
}