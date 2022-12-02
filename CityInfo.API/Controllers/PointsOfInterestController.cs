using CityInfo.API.Data;
using CityInfo.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace CityInfo.API.Controllers
{
    [Route("api/cities/{cityId}/[controller]")]
    [ApiController]
    public class PointsOfInterestController : ControllerBase
    {
        private readonly IPointsOfInterestDataStore _pointsOfInterestDataStore;

        public PointsOfInterestController(IPointsOfInterestDataStore pointsOfInterestDataStore)
        {
            _pointsOfInterestDataStore = pointsOfInterestDataStore;
        }
        
        [HttpGet]
        public ActionResult<IEnumerable<PointOfInterest>> GetPointsOfInterest(int cityId)
        {
            var pointsOfInterest = _pointsOfInterestDataStore.GetPointsOfInterestForCity(cityId);
            if (pointsOfInterest==null)
            {
                return NotFound();
            }

            return Ok(pointsOfInterest);
        }
    }
    
    public interface IPointsOfInterestDataStore
    {
        IEnumerable<PointOfInterest> GetPointsOfInterestForCity(int cityId);
    }
}
