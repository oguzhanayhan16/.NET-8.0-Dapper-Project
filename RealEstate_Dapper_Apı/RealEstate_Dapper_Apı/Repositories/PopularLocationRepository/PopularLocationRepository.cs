using Dapper;
using RealEstate_Dapper_API.Dtos.PopulerLocationDtos;
using RealEstate_Dapper_API.Dtos.ServiceDtos;
using RealEstate_Dapper_API.Properties.Models.DapperContext;

namespace RealEstate_Dapper_API.Repositories.PopularLocationRepository
{
    public class PopularLocationRepository : IPopularLocationRepository
    {
        private readonly Context _context;

        public PopularLocationRepository(Context context)
        {
            _context = context;
        }

        public async Task CreatePopularLocation(CreatePopularLocationDto PopularLocationDto)
        { 
            string query = "insert into PopularLocation (CityName,ImageUrl) values (@CityName,@ImageUrl)";
            var paramaters = new DynamicParameters();
            paramaters.Add("@CityName", PopularLocationDto.CityName);
            paramaters.Add("@ImageUrl", PopularLocationDto.ImageUrl);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, paramaters);

            }
        }

        public async Task DeletePopularLocation(int id)
        {
            string query = "Delete from PopularLocation Where LocationID=@LocationID";
            var paramaters = new DynamicParameters();
            paramaters.Add("@LocationID", id);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, paramaters);
            }
        }

        public async Task<List<ResultPopulerLocationDto>> GetAllPopularLocationAsync()
        {
            string query = "Select * from PopularLocation";

            try
            {
                using (var connection = _context.CreateConnection())
                {
                    var values = await connection.QueryAsync<ResultPopulerLocationDto>(query);
                    return values.ToList();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                throw;
            }
        }

        public async Task<GetByIDPopularLocationDto> GetPopularLocation(int id)
        {
            string query = " Select * from PopularLocation Where LocationID=@LocationID";
            var paramaters = new DynamicParameters();
            paramaters.Add("@LocationID", id);
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryFirstOrDefaultAsync<GetByIDPopularLocationDto>(query, paramaters);
                return values;

            }
        }

        public async Task UpdatePopularLocation(UpdatePopularLocationDto PopularLocationDto)
        {

            string query = "Update PopularLocation Set CityName=@CityName, ImageUrl=@ImageUrl where LocationID=@LocationID";
            var paramaters = new DynamicParameters();
            paramaters.Add("@CityName", PopularLocationDto.CityName);
            paramaters.Add("@ImageUrl", PopularLocationDto.ImageUrl);
            paramaters.Add("@LocationID", PopularLocationDto.LocationID);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, paramaters);
            }
        }
    }
}
