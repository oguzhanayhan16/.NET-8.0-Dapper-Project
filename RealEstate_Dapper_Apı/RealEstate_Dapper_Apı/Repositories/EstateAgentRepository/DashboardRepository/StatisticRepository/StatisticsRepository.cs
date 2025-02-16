using Dapper;
using RealEstate_Dapper_API.Properties.Models.DapperContext;

namespace RealEstate_Dapper_API.Repositories.EstateAgentRepository.DashboardRepository.StatisticRepository
{
    public class StatisticsRepository : IStatisticsRepository
    {
        private readonly Context _context;

        public StatisticsRepository(Context context)
        {
            _context = context;
        }
        public int AllProductCount()
        {
            string query = "Select Count(*) from Product";

            try
            {
                using (var connection = _context.CreateConnection())
                {
                    var values = connection.QueryFirstOrDefault<int>(query);
                    return values;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                throw;
            }
        }

        public int ProductCount(int id)
        {
            string query = "Select Count(*) from Product Where AppUserID=@employeeId";
            var paramaters = new DynamicParameters();
            paramaters.Add("@employeeId", id);
            try
            {
                using (var connection = _context.CreateConnection())
                {
                    var values = connection.QueryFirstOrDefault<int>(query,paramaters);
                    return values;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                throw;
            }
        }

        public int ProductCountByStatusFalse(int id)
        {
            string query = "Select Count(*) from Product Where AppUserID=@employeeId and ProductStatus=0";
            var paramaters = new DynamicParameters();
            paramaters.Add("@employeeId", id);
            try
            {
                using (var connection = _context.CreateConnection())
                {
                    var values = connection.QueryFirstOrDefault<int>(query, paramaters);
                    return values;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                throw;
            }
        }

        public int ProductCountByStatusTrue(int id)
        {
            string query = "Select Count(*) from Product Where AppUserID=@employeeId and ProductStatus=1";
            var paramaters = new DynamicParameters();
            paramaters.Add("@employeeId", id);
            try
            {
                using (var connection = _context.CreateConnection())
                {
                    var values = connection.QueryFirstOrDefault<int>(query,paramaters);
                    return values;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                throw;
            }
        }
    }
}
