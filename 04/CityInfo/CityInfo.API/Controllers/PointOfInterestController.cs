using CityInfo.API.Models;
using CityInfo.API.Services;
using CityInfo.API.Validators;
using FluentValidation.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace CityInfo.API.Controllers
{
    [Route("api/{cityId}/[controller]")]
    [ApiController]
    public class PointOfInterestController : ControllerBase
    {
        private readonly ILogger<PointOfInterestController> _logger;
        private readonly LocalMailService _localMailService;
        public PointOfInterestController(
            ILogger<PointOfInterestController> logger,
            LocalMailService localMailService
            ) {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
        [HttpGet("")]
        public ActionResult<IEnumerable<PointOfInterestDto>> GetPointsOfInterest(int cityId)
        {
            try {

                var city = FindCityById(cityId);
                if (city == null)
                {
                    _logger.LogInformation($"City Id {cityId} not found, [GetPointsOfInterest,PointOfInterestController]");
                    return NotFound();
                }
                return Ok(city.PointsOfInterest);
            
            }
            catch(Exception ex)
            {
                _logger.LogCritical($"Error City Id {cityId} [GetPointsOfInterest,PointOfInterestController]", ex);
                return StatusCode(500, "A problem happened");
            }
        }

        [HttpGet("{pointOfInterestId}")]
        public ActionResult<PointOfInterestDto> GetPointOfInterest(int cityId, int pointOfInterestId)
        {
            var city = FindCityById(cityId);
            if (city == null)
            {
                return NotFound(new JsonResult(new { message = "City not found" }));
            }
            var poi = city.PointsOfInterest.FirstOrDefault(p => p.Id == pointOfInterestId);
            if (poi == null)
            {
                return NotFound(new JsonResult(new { message = "PoI not found" }));
            }
            return Ok(poi);
        }

        private CityDto? FindCityById(int cityId)
        {
            return CitiesDataStore.Current.Cities.FirstOrDefault(c => c.Id == cityId);
        }
        [HttpPut("{pointOfInterestId}")]
        public ActionResult UpdatePointOfInterest(
            [FromRoute] int cityId,
            [FromRoute] int pointOfInterestId,
            [FromBody] PointOfInterestUpdateDto poiToUpdate
            )
        {
            var city = CitiesDataStore.Current.Cities
                .FirstOrDefault(c => c.Id == cityId);
            if (city == null)
            {
                return NotFound();
            }
            var poiFromStore = city.PointsOfInterest.FirstOrDefault(c => c.Id == pointOfInterestId);
            if (poiFromStore == null)
            {
                return NotFound();
            }

            PointOfInterestUpdatevalidator validator = new PointOfInterestUpdatevalidator();
            ValidationResult result = validator.Validate(poiToUpdate);
            if (!result.IsValid)
            {
                foreach (var failure in result.Errors)
                {
                    Console.WriteLine("Property " + failure.PropertyName + " failed validation. Error was: " + failure.ErrorMessage);
                }
                return BadRequest();
            }
            poiFromStore.Name = poiToUpdate.Name;
            poiFromStore.Description = poiToUpdate.Description;
            return NoContent();
        }


        [HttpPatch("{pointOfInterestId}")]
        public ActionResult PartiallyUpdatePointOfInterest(
            [FromRoute] int cityId,
            [FromRoute] int pointOfInterestId,
            [FromBody] JsonPatchDocument<PointOfInterestUpdateDto> poiToPatch
            )
        {
            var city = CitiesDataStore.Current.Cities
                .FirstOrDefault(c => c.Id == cityId);
            if (city == null)
            {
                return NotFound();
            }
            var poiFromStore = city.PointsOfInterest.FirstOrDefault(c => c.Id == pointOfInterestId);
            if (poiFromStore == null)
            {
                return NotFound();
            }

            var poiPatched = new PointOfInterestUpdateDto()
            {
                Name = poiFromStore.Name,
                Description = poiFromStore.Description
            };

            poiToPatch.ApplyTo(poiPatched, ModelState);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            PointOfInterestUpdatevalidator validator = new PointOfInterestUpdatevalidator();
            ValidationResult result = validator.Validate(poiPatched);
            if (!result.IsValid)
            {
                foreach (var failure in result.Errors)
                {
                    Console.WriteLine("Property " + failure.PropertyName + " failed validation. Error was: " + failure.ErrorMessage);
                }
                return BadRequest();
            }
            poiFromStore.Name = poiPatched.Name;
            poiFromStore.Description = poiPatched.Description;
            return NoContent();
        }
        [HttpDelete("{pointOfInterestId}")]
        public ActionResult DeletePointOfInterest(
            [FromRoute] int cityId,
            [FromRoute] int pointOfInterestId
            )
        {
            var city = CitiesDataStore.Current.Cities
                .FirstOrDefault(c => c.Id == cityId);
            if (city == null)
            {
                return NotFound();
            }
            var poiFromStore = city.PointsOfInterest.FirstOrDefault(c => c.Id == pointOfInterestId);
            if (poiFromStore == null)
            {
                return NotFound();
            }
            city.PointsOfInterest.Remove(poiFromStore);
            _localMailService.Send("REMOVE", $"PoI with id: ${pointOfInterestId} from city {city.Name} was deleted");
            return NoContent();
        }
    }
}
