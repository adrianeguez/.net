﻿using CityInfo.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace CityInfo.API.Controllers
{
    [ApiController]
    [Route("api/cities")] //api/[controller] => api/cities
    public class CitiesController : ControllerBase
    {
        [HttpGet("")]
        public ActionResult<CityDto[]> GetCities()
        {
            return Ok(CitiesDataStore.Current.Cities);
        }
        [HttpGet("{id}")]
        public ActionResult<CityDto> GetCity(int id) {
            var city = CitiesDataStore.Current.Cities.FirstOrDefault(c => c.Id == id);
            if(city == null)
            {
                return NotFound("Id not found");
            }
            return city;
        }
    }
}
