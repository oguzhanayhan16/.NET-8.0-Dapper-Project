using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_API.Properties.Models.DapperContext;
using RealEstate_Dapper_API.Repositories.EstateAgentRepository.DashboardRepository.ChartRespository;

namespace RealEstate_Dapper_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstateAgentChartController : ControllerBase
    {
        private readonly IChartRepository _chartRepository;

        public EstateAgentChartController(IChartRepository chartRepository)
        {
            _chartRepository = chartRepository;
        }

        [HttpGet]
        public async Task<IActionResult> ProductList()
        {
            var values = await _chartRepository.Get5CityForChart();
            return Ok(values);
        }
    }
}
