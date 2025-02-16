using Dapper;
using RealEstate_Dapper_API.Dtos.CategoryDtos;
using RealEstate_Dapper_API.Dtos.ServiceDtos;
using RealEstate_Dapper_API.Dtos.WhoWeAreDetailDtos;
using RealEstate_Dapper_API.Properties.Models.DapperContext;

namespace RealEstate_Dapper_API.Repositories.ServiceRepository
{
    public class ServiceRepository:IServiceRepository
    {
        private readonly Context _context;

        public ServiceRepository(Context context)
        {
            _context = context;
        }

        public async Task CreateService(CreateServiceDto serviceDto)
        {
            string query = "insert into Service (ServiceName,ServiceStatus) values (@ServiceName,@ServiceStatus)";
            var paramaters = new DynamicParameters();
            paramaters.Add("@ServiceName", serviceDto.ServiceName);
            paramaters.Add("@ServiceStatus", true);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, paramaters);

            }
        }

        public async Task DeleteService(int id)
        {
            string query = "Delete from Service Where ServiceID=@ServiceID";
            var paramaters = new DynamicParameters();
            paramaters.Add("@ServiceID", id);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, paramaters);
            }
        }

        public async Task<List<ResultServiceDto>> GetAllServiceAsync()
        {
            string query = "Select * from Service";

            try
            {
                using (var connection = _context.CreateConnection())
                {
                    var values = await connection.QueryAsync<ResultServiceDto>(query);
                    return values.ToList();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                throw;
            }
        }

        public async Task<GetByIDServiceDto> GetService(int id)
        {
            string query = " Select * from Service Where ServiceID=@ServiceID";
            var paramaters = new DynamicParameters();
            paramaters.Add("@ServiceID", id);
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryFirstOrDefaultAsync<GetByIDServiceDto>(query, paramaters);
                return values;

            }
        }

        public async Task UpdateService(UpdateServiceDto serviceDto)
        {
            string query = "Update Service Set ServiceName=@ServiceName, ServiceStatus=@ServiceStatus where ServiceID=@ServiceID";
            var paramaters = new DynamicParameters();
            paramaters.Add("@ServiceName", serviceDto.ServiceName);
            paramaters.Add("@ServiceStatus", serviceDto.ServiceStatus);
            paramaters.Add("@ServiceID", serviceDto.ServiceID);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, paramaters);
            }
        }
    }
}
