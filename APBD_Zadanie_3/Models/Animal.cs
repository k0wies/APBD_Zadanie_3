using System.ComponentModel.DataAnnotations;

namespace APBD_Zadanie_3.Models;

public class Animal
{
    public int idAnimal { get; set; }
    public string name { get; set; }
    public string description{ get; set; }
    public string category{ get; set; }
    public string area{ get; set; }
}