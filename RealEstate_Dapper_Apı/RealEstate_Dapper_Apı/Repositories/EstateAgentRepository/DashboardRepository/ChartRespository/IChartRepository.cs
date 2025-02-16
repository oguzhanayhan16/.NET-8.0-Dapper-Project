using RealEstate_Dapper_API.Dtos.ChartDtos;

namespace RealEstate_Dapper_API.Repositories.EstateAgentRepository.DashboardRepository.ChartRespository
{
    public interface IChartRepository
    {
        Task<List<ResultChartDto>> Get5CityForChart();
    }
}
