using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_API.Dtos.EmployeeDtos;
using RealEstate_Dapper_API.Repositories.EmployeeRepository;

namespace RealEstate_Dapper_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeesController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        [HttpGet]
        public async Task<IActionResult> EmpoloyeeList()
        {
            var values = await _employeeRepository.GetAllEmployeeAsync();
            return Ok(values);
        }
        [HttpPost]
        public async Task<IActionResult> CreateEmpoloyee(CreateEmployeeDto createEmpoloyee)
        {
            await _employeeRepository.CreateEmployee(createEmpoloyee);
            return Ok("kategori başarıyla oluşturuldu");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmpoloyee(int id)
        {
            await _employeeRepository.DeleteEmployee(id);
            return Ok("kategori silindi");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateEmpoloyee(UpdateEmployeeDto updateEmpoloyeeDto)
        {
            await _employeeRepository.UpdateEmployee(updateEmpoloyeeDto);
            return Ok("Kategori Başarıyla Güncellendi");
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmpoloyee(int id)
        {
            var value = await _employeeRepository.GetEmployee(id);
            return Ok(value);
        }
    }
}
