using RealEstate_Dapper_API.Dtos.AppUserDtos;

namespace RealEstate_Dapper_API.Repositories.AppUserRepository
{
    public interface IAppUserRepository
    {
        Task<GetAppUserByProductIdDto> GetAppUserById(int id);
    }
}
