using RealEstate_Dapper_API.Dtos.PropertyAmenityDtos;

namespace RealEstate_Dapper_API.Repositories.PropertyAmenityRepository
{
    public interface IPropertyAmenityRepository
    {
        Task<List<ResultPropertyAmenityByStatusTrueDto>> ResultPropertyAmenityByStatusTrue(int id);
    }
}
