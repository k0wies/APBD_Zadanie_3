using APBD_Zadanie_3.Models;

namespace APBD_Zadanie_3.Interfaces;

public interface IAnimalRepository
{
    IEnumerable<Animal> FetchAnimals();
}