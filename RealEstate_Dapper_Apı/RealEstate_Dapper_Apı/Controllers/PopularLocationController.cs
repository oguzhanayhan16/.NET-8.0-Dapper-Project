using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_API.Dtos.PopulerLocationDtos;
using RealEstate_Dapper_API.Repositories.BottomGridRepository;
using RealEstate_Dapper_API.Repositories.PopularLocationRepository;

namespace RealEstate_Dapper_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PopularLocationController : ControllerBase
    {
        private readonly IPopularLocationRepository _popularLocationRepository;

        public PopularLocationController(IPopularLocationRepository popularLocationRepository)
        {
            _popularLocationRepository = popularLocationRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetPopularLocationList()
        {
            var values = await _popularLocationRepository.GetAllPopularLocationAsync();
            return Ok(values);
        }
        [HttpPost]
        public async Task<IActionResult> CreatePopularLocation(CreatePopularLocationDto PopularLocation)
        {
            await _popularLocationRepository.CreatePopularLocation(PopularLocation);
            return Ok("hakkımızda başarıyla oluşturuldu");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePopularLocation(int id)
        {
            await _popularLocationRepository.DeletePopularLocation(id);
            return Ok("hakkımızda silindi");
        }
        [HttpPut]
        public async Task<IActionResult> UpdatePopularLocation(UpdatePopularLocationDto updatePopularLocation)
        {
            await _popularLocationRepository.UpdatePopularLocation(updatePopularLocation);
            return Ok("hakkımızda güncellendi");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPopularLocation(int id)
        {
            var value = await _popularLocationRepository.GetPopularLocation(id);
            return Ok(value);
        }
    }
}
