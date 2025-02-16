using RealEstate_Dapper_API.Dtos.CategoryDtos;
using RealEstate_Dapper_API.Dtos.WhoWeAreDetailDtos;

namespace RealEstate_Dapper_API.Repositories.WhoWeAreRepository
{
    public interface IWhoWeAreRepostiyory
    {
        Task<List<ResultWhoWeAreDetailDto>> GetAllWhoWeAreAsync();
        Task CreateWhoWeAre(CreateWhoWeAreDetailDto createWhoWeAre);
        Task DeleteWhoWeAre(int id);

        Task UpdateWhoWeAre(UpdateWhoWeAreDetailDto updateWhoWeAreDto);

        Task<GetByIDWhoWeAreDto> GetWhoWeAre(int id);
    }
}
