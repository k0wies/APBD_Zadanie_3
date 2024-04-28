using APBD_Zadanie_3.Controllers;
using APBD_Zadanie_3.DTOs;
using APBD_Zadanie_3.Interfaces;
using APBD_Zadanie_3.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace APBD_Zadanie_3.Services;

public class AnimalService : IAnimalService
{
    private readonly IAnimalRepository _animalRepository;

    public AnimalService(IAnimalRepository animalRepository)
    {
        _animalRepository = animalRepository;
    }

    public IEnumerable<AnimalDTO> GetAnimals(string orderBy)
    {
        var animals = from b in _animalRepository.FetchAnimals()
            select new AnimalDTO()
            {
                idAnimal = b.idAnimal,
                name = b.name,
                area = b.area,
                description = b.description,
                category = b.category
                
            };
        switch (orderBy)
        {
            case "name":  animals = animals.OrderBy(animal => animal.name);
                break;
            case "area":  animals = animals.OrderBy(animal => animal.area);
                break;
            case "description":  animals = animals.OrderBy(animal => animal.description);
                break;
            case "category":  animals = animals.OrderBy(animal => animal.category);
                break;
        }

        return animals;
    }
    
    
    [HttpGet("{id:int}")]
    public AnimalDTO GetAnimal(int id)
    {
        var animal = _animalRepository.FetchAnimals().FirstOrDefault(s => s.idAnimal == id);

        var animals = 
            new AnimalDTO()
            {
                idAnimal = animal.idAnimal,
                name = animal.name,
                area = animal.area,
                description = animal.description,
                category = animal.category
                
            };
        return animals;
    }

    public int CreateAnimal(AnimalCreationDTO animal)
    {
        throw new NotImplementedException();
    }

    public int DeleteAnimal(int id)
    {
        throw new NotImplementedException();
    }

    public int UpdateAnimal(AnimalUpdateDTO animal)
    {
        throw new NotImplementedException();
    }
}