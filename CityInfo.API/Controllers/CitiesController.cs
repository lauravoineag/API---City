using CityInfo.API.Data;
using CityInfo.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace CityInfo.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CitiesController:ControllerBase
{
    private readonly ICitiesDataStore _citiesDataStore;
    public CitiesController(ICitiesDataStore citiesDataStore)
    {
        _citiesDataStore = citiesDataStore;
    }
    
    [HttpGet]
    public ActionResult<IEnumerable<City>> GetCities()
    {
       return Ok(_citiesDataStore.GetCities());
    }

    [HttpGet("{id}")]
    public ActionResult<City> GetCity(int id)
    {
        //find city 
        var cityToReturn = _citiesDataStore.GetCity(id);
        if (cityToReturn == null)
        {
            return NotFound();
        }
        return Ok(cityToReturn); 
    }
    
}

public interface ICitiesDataStore
{
    IEnumerable<City> GetCities();
    City GetCity(int id);
}