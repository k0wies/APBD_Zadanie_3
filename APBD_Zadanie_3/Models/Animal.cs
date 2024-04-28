using System.ComponentModel.DataAnnotations;

namespace APBD_Zadanie_3.Models;

public class Animal
{
    public int idAnimal { get; set; }
    [Required]
    public string name { get; set; }
    [Required]
    public string description{ get; set; }
    public string category{ get; set; }
    public string area{ get; set; }
}