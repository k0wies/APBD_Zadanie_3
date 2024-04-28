using APBD_Zadanie_3.DTOs;

namespace APBD_Zadanie_3.Interfaces;

public interface IAnimalService
{
    public IEnumerable<AnimalDTO> GetAnimals(string orderBy);

    public AnimalDTO GetAnimal(int id);

    public int CreateAnimal(AnimalCreationDTO animal);
    
    public int DeleteAnimal(int id);
    
    public int UpdateAnimal(AnimalUpdateDTO animal);
}