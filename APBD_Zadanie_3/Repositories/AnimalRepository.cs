using System.Data.SqlClient;
using APBD_Zadanie_3.Interfaces;
using APBD_Zadanie_3.Models;

namespace APBD_Zadanie_3.Repositories;

public class AnimalRepository : IAnimalRepository
{
    private IConfiguration _configuration;
    
    public static List<Animal> _animals = new()
    {
        new Animal() { idAnimal = 11, name = "aaa", area = "aaa", description = "bbb", category = "ccc" },
        new Animal() { idAnimal = 21, name = "bbb", area = "aaa", description = "ee", category = "aa" }
    };

    public AnimalRepository(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public IEnumerable<Animal> GetAnimals()
    {
        using var con = new SqlConnection(_configuration["ConnectionString:DefaultConnection"]);
        con.Open();

        using var cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandText = "SELECT Id, Name, Description, Category, Area FROM Animals";

        var dr = cmd.ExecuteReader();
        var animals = new List<Animal>();
        while (dr.Read())
        {
            var grade = new Animal
            {
                idAnimal = (int)dr["Id"],
                name = dr["Name"].ToString(),
                description = dr["Description"].ToString(),
                category = dr["Category"].ToString(),
                area = dr["Area"].ToString()
            };
            animals.Add(grade);
        }
        con.Close();
        return animals;
    }

    public static void AddAnimal(Animal animal)
    {
        _animals.Add(animal);
    }
    
    public IEnumerable<Animal> FetchAnimals()
    {
        return _animals;
    }
}