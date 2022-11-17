using CityInfo.API.Models;

namespace CityInfo.API.Data;

public class CityDataStore
{
    public List<City> Cities { get; set; }

    public CityDataStore()
    {
        //init dummy data
        Cities = new List<City>()
        {
            new City()
            {
                Id = 1,
                Name = "Manchester",
                Description = "The one where I live."
            },
            new City()
            {
                Id = 2,
                Name = "London",
                Description = "The one that is really crowded."
            },
            new City()
            {
                Id = 3,
                Name = "Liverpool",
                Description = "The one where Beatles are from"
            }
        };
    }
}