using RealEstate_Dapper_API.Dtos.SubFeatureDtos;

namespace RealEstate_Dapper_API.Repositories.SubFeatureRepository
{
    public interface ISubFeatureRepository
    {
        Task<List<ResultSubFeatureDto>> GetAllSubFeatureAsync();
    }
}
