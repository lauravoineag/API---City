﻿using CityInfo.API.Controllers;
using CityInfo.API.Models;

namespace CityInfo.API.Data;

public class CitiesDataStore:ICitiesDataStore,IPointsOfInterestDataStore
{
    private readonly List<City> _cities;
    
    public IEnumerable<City> GetCities()
    {
        return _cities;
    }

    public City GetCity(int id)
    {
        return _cities.FirstOrDefault(c => c.Id == id);
    }
    
    public IEnumerable<PointOfInterest> GetPointsOfInterestForCity(int cityId)
    {
        var city=_cities.FirstOrDefault(c => c.Id == cityId);
        if (city==null)
        {
            return null;
        } 
        return city.PointsOfInterest;
    }

    public CitiesDataStore()
    {
        //init dummy data
        _cities = new List<City>()
        {
            new City()
            {
                Id = 1,
                Name = "New York City",
                Description = "The one where I live.",
                PointsOfInterest = new List<PointOfInterest>()
                {
                    new PointOfInterest()
                    {
                        Id = 1,
                        Name = "Central Park",
                        Description = "The most visited urban park in the United States."
                    },
                    new PointOfInterest()
                    {
                        Id = 2,
                        Name = "Empire State Building",
                        Description = "A 102-story skyscraper located in Midtown Manhattan."
                    },
                }
            },
            new City()
            {
                Id = 2,
                Name = "Antwerp",
                Description = "The one with the cathedral that was never really finished.",
                PointsOfInterest = new List<PointOfInterest>()
                {
                    new PointOfInterest()
                    {
                        Id = 3,
                        Name = "Cathedral of Our Lady",
                        Description = "A Gothic style cathedral, conceived by architects Jan and Pieter Appelmans."
                    },
                    new PointOfInterest()
                    {
                        Id = 4,
                        Name = "Antwerp Central Station",
                        Description = "The the finest example of railway architecture in Belgium."
                    },
                }
            },
            new City()
            {
                Id = 3,
                Name = "Paris",
                Description = "The one with the big tower",
                PointsOfInterest = new List<PointOfInterest>()
                {
                    new PointOfInterest()
                    {
                        Id = 5,
                        Name = "Eiffel Tower",
                        Description =
                            "A wrought iron lattice tower on the Champ de Mars, named after engineer Gustave Eiffel."
                    },
                    new PointOfInterest()
                    {
                        Id = 6,
                        Name = "The Louvre",
                        Description = "The world's largest museum."
                    },
                }
            }
        };
    }
}