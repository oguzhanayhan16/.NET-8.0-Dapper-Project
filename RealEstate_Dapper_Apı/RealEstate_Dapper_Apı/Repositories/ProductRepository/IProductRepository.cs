
using RealEstate_Dapper_API.Dtos.ProductDetailDtos;
using RealEstate_Dapper_API.Dtos.ProductDtos;

namespace RealEstate_Dapper_API.Repositories.ProductRepository
{
    public interface IProductRepository
    {
        Task<List<ResultProductDto>> GetAllProductAsync();
        Task<List<ResultProductAdvertListWitchCategoryByEmployeeDto>> GetProductListAdvertListByEmpoleeAsyncByTrue(int id);
        Task<List<ResultProductAdvertListWitchCategoryByEmployeeDto>> GetProductListAdvertListByEmpoleeAsyncByFalse(int id);
        Task<List<ResultProductWtihCategoryDto>> GetAllProductWithCategory();

        Task ProductDealOfTheDayStatusChangeTrue(int id);
        Task ProductDealOfTheDayStatusChangeFalse(int id);
        Task<List<ResultLast5ProductDto>> GetLast5ProductAsync();
        Task<List<ResultLast5ProductDto>> GetLast3ProductAsync();
        Task<List<ResulProductWithSearchListDto>> ResultProductWithSearchList(string serachKeyValue,int propertyCategoryId,string city);
        Task CreateProduct(CreateProductDto createProductDto);

        Task<GetProductByIdDto> GetProductById(int id);
        Task<GetProudctDetailByIdDto> GetProductDetailByProductId(int id);

        Task<List<ResultProductWtihCategoryDto>> GetProductByealOfTheDayTrue();

    }
}
