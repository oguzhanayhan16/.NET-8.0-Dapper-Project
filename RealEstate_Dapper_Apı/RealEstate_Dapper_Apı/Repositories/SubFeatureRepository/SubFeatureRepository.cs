using Dapper;
using RealEstate_Dapper_API.Dtos.SubFeatureDtos;
using RealEstate_Dapper_API.Properties.Models.DapperContext;

namespace RealEstate_Dapper_API.Repositories.SubFeatureRepository
{
    public class SubFeatureRepository:ISubFeatureRepository
    {
        private readonly Context _context;

        public SubFeatureRepository(Context context)
        {
            _context = context;
        }

        public async Task<List<ResultSubFeatureDto>> GetAllSubFeatureAsync()
        {
            string query = "Select * from Category";

            try
            {
                using (var connection = _context.CreateConnection())
                {
                    var values = await connection.QueryAsync<ResultSubFeatureDto>(query);
                    return values.ToList();
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
