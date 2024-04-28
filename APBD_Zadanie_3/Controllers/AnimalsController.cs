using APBD_Zadanie_3.DTOs;
using APBD_Zadanie_3.Interfaces;
using APBD_Zadanie_3.Models;
using APBD_Zadanie_3.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace APBD_Zadanie_3.Controllers;

[Route("api/animals")]
[ApiController]
public class AnimalsController : ControllerBase
{
    
    private IAnimalService _animalService;
    private readonly IAnimalRepository _animalRepository;

    public AnimalsController(IAnimalService animalService, IAnimalRepository animalRepository)
    {
        _animalService = animalService;
        _animalRepository = animalRepository;
    }

    [HttpGet]
    public IActionResult GetAnimals([FromQuery] string orderBy = "name")
    {
        return Ok(_animalService.GetAnimals(orderBy));
    }
    
    [HttpGet("{id:int}")]
    public IActionResult GetAnimal(int id)
    {
        var animal = _animalRepository.FetchAnimals().FirstOrDefault(s => s.idAnimal == id);
        if (animal == null)
        {
            return NotFound($"Animal with id {id} was not found");
        }
        return Ok(animal);
    }
    
    [HttpPost]
    public IActionResult CreateAnimal(AnimalDTO animalDto)
    {
        var animal = new Animal
        {
            idAnimal = AnimalRepository.getHighestId()+1,
            name = animalDto.name,
            description = animalDto.description,
            category = animalDto.category,
            area = animalDto.area
        };

        AnimalRepository.AddAnimal(animal);

        return StatusCode(StatusCodes.Status201Created);
    }
    
    [HttpPut("{id:int}")]
    public IActionResult UpdateAnimal(int id, Animal animal)
    {
        var animalToEdit = _animalRepository.FetchAnimals().FirstOrDefault(s => s.idAnimal == id);
        
        if (animalToEdit == null)
        {
            return NotFound($"Animal with id {id} was not found");
        }
        
        AnimalRepository.RemoveAnimal(animalToEdit);
        AnimalRepository.AddAnimal(animal);
        return StatusCode(StatusCodes.Status200OK);
    }
    
    [HttpDelete("{id:int}")]
    public IActionResult DeleteAnimal(int id)
    {
        var animalToDelete = _animalRepository.FetchAnimals().FirstOrDefault(s => s.idAnimal == id);
        
        if (animalToDelete == null)
        {
            return NotFound($"Animal with id {id} was not found");
        }
        
        AnimalRepository.RemoveAnimal(animalToDelete);
        return StatusCode(StatusCodes.Status200OK);
    }
    
}