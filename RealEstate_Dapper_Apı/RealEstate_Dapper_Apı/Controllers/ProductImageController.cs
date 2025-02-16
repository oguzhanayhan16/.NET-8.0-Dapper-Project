using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_API.Repositories.ProductImageRepository;

namespace RealEstate_Dapper_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductImageController : ControllerBase
    {
        private readonly IProductImageRepository productImageRepository;

        public ProductImageController(IProductImageRepository productImageRepository)
        {
            this.productImageRepository = productImageRepository;
        }

        [HttpGet]

        public async Task<IActionResult> GetProductImageById(int id)
        {
            var values = await productImageRepository.GetProductImageById(id);
            return Ok(values);
        }
    }
}
