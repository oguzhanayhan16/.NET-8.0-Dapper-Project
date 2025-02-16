using RealEstate_Dapper_API.Dtos.ServiceDtos;

namespace RealEstate_Dapper_API.Repositories.ServiceRepository
{
    public interface IServiceRepository
    {
        Task<List<ResultServiceDto>> GetAllServiceAsync();
        Task CreateService(CreateServiceDto serviceDto);
        Task DeleteService(int id);

        Task UpdateService(UpdateServiceDto serviceDto);

        Task<GetByIDServiceDto> GetService(int id);
    }
}
