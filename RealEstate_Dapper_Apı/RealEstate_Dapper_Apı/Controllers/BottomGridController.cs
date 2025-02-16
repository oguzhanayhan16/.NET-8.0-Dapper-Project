using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_API.Dtos.BottomGridDtos;
using RealEstate_Dapper_API.Repositories.BottomGridRepository;

namespace RealEstate_Dapper_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BottomGridController : ControllerBase
    {
        private readonly IBottomGridRepository _bottomGridRepository;

        public BottomGridController(IBottomGridRepository bottomGridRepository)
        {
            _bottomGridRepository = bottomGridRepository;
        }
        [HttpGet]
        public async Task<IActionResult> BottomGridList()
        {
            var values = await _bottomGridRepository.GetAllBottomGridAsync();
            return Ok(values);
        }
        [HttpPost]
        public async Task<IActionResult> CreateBottomGrid(CreateBottomGridDto BottomGrid)
        {
            await _bottomGridRepository.CreateBottomGrid(BottomGrid);
            return Ok("hakkımızda başarıyla oluşturuldu");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBottomGrid(int id)
        {
            await _bottomGridRepository.DeleteBottomGrid(id);
            return Ok("hakkımızda silindi");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateBottomGrid(UpdateBottomGridDto updateBottomGrid)
        {
            await _bottomGridRepository.UpdateBottomGrid(updateBottomGrid);
            return Ok("hakkımızda güncellendi");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBottomGrid(int id)
        {
            var value = await _bottomGridRepository.GetBottomGrid(id);
            return Ok(value);
        }
    }
}
