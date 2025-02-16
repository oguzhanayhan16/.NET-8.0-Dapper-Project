using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_API.Dtos.ServiceDtos;
using RealEstate_Dapper_API.Repositories.ServiceRepository;

namespace RealEstate_Dapper_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceController : ControllerBase
    {
        private readonly IServiceRepository _serviceRepository;

        public ServiceController(IServiceRepository serviceRepository)
        {
            _serviceRepository = serviceRepository;
        }
        [HttpGet]
        public async Task<IActionResult> GetServiceList()
        {
            var values = await _serviceRepository.GetAllServiceAsync();
            return Ok(values);
        }
        [HttpPost]
        public async Task<IActionResult> CreateService(CreateServiceDto Service)
        {
            await _serviceRepository.CreateService(Service);
            return Ok("hakkımızda başarıyla oluşturuldu");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteService(int id)
        {
            await _serviceRepository.DeleteService(id);
            return Ok("hakkımızda silindi");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateService(UpdateServiceDto updateService)
        {
            await _serviceRepository.UpdateService(updateService);
            return Ok("hakkımızda güncellendi");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetService(int id)
        {
            var value = await _serviceRepository.GetService(id);
            return Ok(value);
        }
    }
}
