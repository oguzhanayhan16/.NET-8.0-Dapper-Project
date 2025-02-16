using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_API.Repositories.StatistikRepostiory;

namespace RealEstate_Dapper_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatistikController : ControllerBase
    {
        private readonly IStatistikRepository _statistikRepository;

        public StatistikController(IStatistikRepository statistikRepository)
        {
            _statistikRepository = statistikRepository;
        }
        [HttpGet("ActiveCategoryCount")]
        public IActionResult ActiveCategoryCount()
        {
            return Ok(_statistikRepository.ActiveCategoryCount());
        }

        [HttpGet("ActiveEmployeeCount")]
        public IActionResult ActiveEmployeeCount()
        {
            return Ok(_statistikRepository.ActiveEmployeeCount());
        }
        [HttpGet("ApartmentCount")]
        public IActionResult ApartmentCount()
        {
            return Ok(_statistikRepository.ApartmentCount());
        }
        [HttpGet("AverageProductPriceByRent")]
        public IActionResult AverageProductPriceByRent()
        {
            return Ok(_statistikRepository.AverageProductPriceByRent());
        }
        [HttpGet("AverageProductPriceBySale")]
        public IActionResult AverageProductPriceBySale()
        {
            return Ok(_statistikRepository.AverageProductPriceBySale());
        }
        [HttpGet("AvaregeRoomCount")]
        public IActionResult AvaregeRoomCount()
        {
            return Ok(_statistikRepository.AvaregeRoomCount());
        }
        [HttpGet("CategoryCount")]
        public IActionResult CategoryCount()
        {
            return Ok(_statistikRepository.CategoryCount());
        }
        [HttpGet("CategoryNameByMaxProduction")]
        public IActionResult CategoryNameByMaxProduction()
        {
            return Ok(_statistikRepository.CategoryNameByMaxProduction());
        }
        [HttpGet("CityNameByMaxProductCount")]
        public IActionResult CityNameByMaxProductCount()
        {
            return Ok(_statistikRepository.CityNameByMaxProductCount());
        }
        [HttpGet("DifferentCityCount")]
        public IActionResult DifferentCityCount()
        {
            return Ok(_statistikRepository.DifferentCityCount());
        }
        [HttpGet("EmployeeNameByMaxProduction")]
        public IActionResult EmployeeNameByMaxProduction()
        {
            return Ok(_statistikRepository.EmployeeNameByMaxProduction());
        }
        [HttpGet("LastProductPrice")]
        public IActionResult LastProductPrice()
        {
            return Ok(_statistikRepository.LastProductPrice());
        }
        [HttpGet("NewestBuildingYear")]
        public IActionResult NewestBuildingYear()
        {
            return Ok(_statistikRepository.NewestBuildingYear());
        }
        [HttpGet("OldestBuildingYear")]
        public IActionResult OldestBuildingYear()
        {
            return Ok(_statistikRepository.OldestBuildingYear());
        }
        [HttpGet("PassiveCategoryCount")]
        public IActionResult PassiveCategoryCount()
        {
            return Ok(_statistikRepository.PassiveCategoryCount());
        }
        [HttpGet("ProductCount")]
        public IActionResult ProductCount()
        {
            return Ok(_statistikRepository.ProductCount());
        }
    }
}
