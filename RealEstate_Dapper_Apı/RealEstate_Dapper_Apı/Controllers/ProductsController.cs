using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_API.Dtos.ProductDtos;
using RealEstate_Dapper_API.Repositories.CategoryRepository;
using RealEstate_Dapper_API.Repositories.ProductRepository;

namespace RealEstate_Dapper_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _productRepository;

        public ProductsController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        [HttpGet]
        public async Task<IActionResult> ProductList()
        {
            var values = await _productRepository.GetAllProductAsync();
            return Ok(values);
        }
        [HttpGet("ProductListWithCategory")]
        public async Task<IActionResult> ProductListWithCategory()
        {
            var values = await _productRepository.GetAllProductWithCategory();
            return Ok(values);
        }

        [HttpGet("ProductDealOfTheDayStatusChangeTrue/{id}")]
        public async Task<IActionResult> ProductDealOfTheDayStatusChangeTrue(int id)
        {
              _productRepository.ProductDealOfTheDayStatusChangeTrue(id);
            return Ok("İlan durumu günün fırsatları arasına eklendi");
        }

        [HttpGet("ProductDealOfTheDayStatusChangeFalse/{id}")]
        public async Task<IActionResult> ProductDealOfTheDayStatusChangeFalse(int id)
        {
            _productRepository.ProductDealOfTheDayStatusChangeFalse(id);
            return Ok("İlan durumu günün fırsatları arasından çıkarıldı");
        }

        [HttpGet("Last5ProductList")]

        public async Task<IActionResult> Last5ProductList()
        {
            var values = await _productRepository.GetLast5ProductAsync();
            return Ok(values);
        }
        [HttpGet("ProdyctAdvertsListByEmplooyeIdTrue")]

        public async Task<IActionResult> ProdyctAdvertsListByEmplooyeIdTrue(int id)
        {
            var values = await  _productRepository.GetProductListAdvertListByEmpoleeAsyncByTrue(id);
            return Ok(values);
        }
        [HttpGet("ProdyctAdvertsListByEmplooyeIdFalse")]

        public async Task<IActionResult> ProdyctAdvertsListByEmplooyeIdFalse(int id)
        {
            var values = await _productRepository.GetProductListAdvertListByEmpoleeAsyncByFalse(id);
            return Ok(values);
        }

        [HttpPost("CreateProduct")]

        public async Task<IActionResult> CreateProduct(CreateProductDto createProductDto)
        {
            await _productRepository.CreateProduct(createProductDto);
            return Ok("İlan başarıyla Eklendi");
        }
           [HttpGet("GetProductById")]

        public async Task<IActionResult> GetProductById(int id)
        {
          var values=  await _productRepository.GetProductById(id);
            return Ok(values);
        }


        [HttpGet("ResultProductWithSearchList")]

        public async Task<IActionResult> ResultProductWithSearchList(string serachKeyValue, int propertyCategoryId, string city)
        {
            var values = await _productRepository.ResultProductWithSearchList(serachKeyValue, propertyCategoryId,city);
            return Ok(values);
        }


        [HttpGet("GetProductByealOfTheDayTrue")]

        public async Task<IActionResult> GetProductByealOfTheDayTrue()
        {
            var values = await _productRepository.GetProductByealOfTheDayTrue();
            return Ok(values);
        }

        [HttpGet("Last3ProductList")]

        public async Task<IActionResult> Last3ProductList()
        {
            var values = await _productRepository.GetLast3ProductAsync();
            return Ok(values);
        }
    }
}
