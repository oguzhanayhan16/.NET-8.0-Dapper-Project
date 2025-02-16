namespace RealEstate_Dapper_API.Repositories.EstateAgentRepository.DashboardRepository.StatisticRepository
{
    public interface IStatisticsRepository
    {
      
        int ProductCount(int id);
        int ProductCountByStatusTrue(int id);
        int ProductCountByStatusFalse(int id);
        int AllProductCount();
     
    }
}
