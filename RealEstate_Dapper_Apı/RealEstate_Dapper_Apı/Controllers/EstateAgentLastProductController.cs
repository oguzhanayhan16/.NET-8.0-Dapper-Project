using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_API.Repositories.EstateAgentRepository.DashboardRepository.LastProcutsRepository;

namespace RealEstate_Dapper_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstateAgentLastProductController : ControllerBase
    {
        private readonly ILastProductRepository lastProductRepository;

        public EstateAgentLastProductController(ILastProductRepository lastProductRepository)
        {
            this.lastProductRepository = lastProductRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetLast5Product(int id)
        {
            var values = await lastProductRepository.GetLast5Product(id);
            return Ok(values);
        }
    }
}
