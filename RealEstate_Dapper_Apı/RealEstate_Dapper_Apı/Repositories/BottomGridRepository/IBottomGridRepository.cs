using RealEstate_Dapper_API.Dtos.BottomGridDtos;
using RealEstate_Dapper_API.Dtos.CategoryDtos;

namespace RealEstate_Dapper_API.Repositories.BottomGridRepository
{
    public interface IBottomGridRepository
    {
        Task<List<ResultBottomGridDto>> GetAllBottomGridAsync();
        Task CreateBottomGrid(CreateBottomGridDto bottomGridDto);
        Task DeleteBottomGrid(int id);

        Task UpdateBottomGrid(UpdateBottomGridDto bottomGridDto);

        Task<GetBottomGridDto> GetBottomGrid(int id);
    }
}
