using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_API.Repositories.PropertyAmenityRepository;

namespace RealEstate_Dapper_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PropertyAmenitiyController : ControllerBase
    {
        private readonly IPropertyAmenityRepository _propertyAmenityRepository;

        public PropertyAmenitiyController(IPropertyAmenityRepository propertyAmenityRepository)
        {
            _propertyAmenityRepository = propertyAmenityRepository;
        }
        [HttpGet]

        public async Task<IActionResult> ResultPropertyAmenity(int id)
        {
            var values =await _propertyAmenityRepository.ResultPropertyAmenityByStatusTrue(id);
            return Ok(values);
        }
    }
}
