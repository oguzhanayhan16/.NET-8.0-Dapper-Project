using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_API.Repositories.EstateAgentRepository.DashboardRepository.StatisticRepository;

namespace RealEstate_Dapper_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstateAgentDashboardStatisticController : ControllerBase
    {
        private readonly IStatisticsRepository _statisticsRepository;

        public EstateAgentDashboardStatisticController(IStatisticsRepository statisticsRepository)
        {
            _statisticsRepository = statisticsRepository;
        }
        [HttpGet("ProductCount")]
        public IActionResult ProductCount(int id)
        {
            return Ok(_statisticsRepository.ProductCount(id));
        }
        [HttpGet("ProductCountByStatusTrue")]
        public IActionResult ProductCountByStatusTrue(int id)
        {
            return Ok(_statisticsRepository.ProductCountByStatusTrue(id));
        }
        [HttpGet("ProductCountByStatusFalse")]
        public IActionResult ProductCountByStatusFalse(int id)
        {
            return Ok(_statisticsRepository.ProductCountByStatusFalse(id));
        }
        [HttpGet("AllProductCount")]
        public IActionResult AllProductCount()
        {
            return Ok(_statisticsRepository.AllProductCount());
        }
    }
}
