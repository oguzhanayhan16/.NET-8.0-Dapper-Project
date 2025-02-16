using RealEstate_Dapper_API.Dtos.ProductDtos;

namespace RealEstate_Dapper_API.Repositories.EstateAgentRepository.DashboardRepository.LastProcutsRepository
{
    public interface ILastProductRepository
    {
        Task<List<ResultLast5ProductDto>> GetLast5Product(int id);
    }
}
