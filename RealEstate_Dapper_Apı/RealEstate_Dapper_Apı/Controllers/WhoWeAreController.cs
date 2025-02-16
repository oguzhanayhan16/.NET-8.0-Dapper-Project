using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_API.Dtos.CategoryDtos;
using RealEstate_Dapper_API.Dtos.WhoWeAreDetailDtos;
using RealEstate_Dapper_API.Repositories.CategoryRepository;
using RealEstate_Dapper_API.Repositories.WhoWeAreRepository;

namespace RealEstate_Dapper_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WhoWeAreController : ControllerBase
    {
        private readonly IWhoWeAreRepostiyory _whoWeAreRepostiyory;

        public WhoWeAreController(IWhoWeAreRepostiyory whoWeAreRepostiyory)
        {
            _whoWeAreRepostiyory = whoWeAreRepostiyory;
        }
        [HttpGet]
        public async Task<IActionResult> WhoWeAreList()
        {
            var values = await _whoWeAreRepostiyory.GetAllWhoWeAreAsync();
            return Ok(values);
        }
        [HttpPost]
        public async Task<IActionResult> CreateWhoWeAre(CreateWhoWeAreDetailDto whoweare)
        {
            await _whoWeAreRepostiyory.CreateWhoWeAre(whoweare);
            return Ok("hakkımızda başarıyla oluşturuldu");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWhoWeAre(int id)
        {
            await _whoWeAreRepostiyory.DeleteWhoWeAre(id);
            return Ok("hakkımızda silindi");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateWhoWeAre(UpdateWhoWeAreDetailDto updateWhoWeAre)
        {
            await _whoWeAreRepostiyory.UpdateWhoWeAre(updateWhoWeAre);
            return Ok("hakkımızda güncellendi");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetWhoWeAre(int id)
        {
            var value = await _whoWeAreRepostiyory.GetWhoWeAre(id);
            return Ok(value);
        }
    }
}
