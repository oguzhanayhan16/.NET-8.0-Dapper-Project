using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_API.Repositories.SubFeatureRepository;

namespace RealEstate_Dapper_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubFeatureController : ControllerBase
    {
        private readonly ISubFeatureRepository _subFeatureRepository;

        public SubFeatureController(ISubFeatureRepository subFeatureRepository)
        {
            _subFeatureRepository = subFeatureRepository;
        }

        [HttpGet]

        public async Task<IActionResult> GetSubFeatureList()
        {
            var values = await _subFeatureRepository.GetAllSubFeatureAsync();
            return Ok(values);
        }
    }
}
