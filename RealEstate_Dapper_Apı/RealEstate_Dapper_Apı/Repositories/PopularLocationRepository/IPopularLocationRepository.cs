using RealEstate_Dapper_API.Dtos.PopulerLocationDtos;


namespace RealEstate_Dapper_API.Repositories.PopularLocationRepository
{
    public interface IPopularLocationRepository
    {
        Task<List<ResultPopulerLocationDto>> GetAllPopularLocationAsync();
        Task CreatePopularLocation(CreatePopularLocationDto PopularLocationDto);
        Task DeletePopularLocation(int id);

        Task UpdatePopularLocation(UpdatePopularLocationDto PopularLocationDto);

        Task<GetByIDPopularLocationDto> GetPopularLocation(int id);
    }
}
