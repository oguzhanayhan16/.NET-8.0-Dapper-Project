using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_API.Repositories.ProductRepository;

namespace RealEstate_Dapper_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductDetailsController : ControllerBase
    {
        private readonly IProductRepository productRepository;

        public ProductDetailsController(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        [HttpGet("GetProductDetailByProductId")]

        public async Task<IActionResult> GetProductDetailByProductId(int id)
        {
            var values = await productRepository.GetProductDetailByProductId(id);
            return Ok(values);
        }
    }
}
