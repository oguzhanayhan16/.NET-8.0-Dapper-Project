using RealEstate_Dapper_API.Dtos.ProductImageDto;

namespace RealEstate_Dapper_API.Repositories.ProductImageRepository
{
    public interface IProductImageRepository
    {
        Task<List<GetProductImageByProductIdDto>> GetProductImageById(int id);
    }
}
