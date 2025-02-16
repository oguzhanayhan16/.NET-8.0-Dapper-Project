using Dapper;
using RealEstate_Dapper_API.Dtos.BottomGridDtos;
using RealEstate_Dapper_API.Dtos.CategoryDtos;
using RealEstate_Dapper_API.Dtos.ServiceDtos;
using RealEstate_Dapper_API.Properties.Models.DapperContext;

namespace RealEstate_Dapper_API.Repositories.BottomGridRepository
{
    public class BottomGridRepository : IBottomGridRepository
    {
        private readonly Context _context;

        public BottomGridRepository(Context context)
        {
            _context = context;
        }
        public async Task CreateBottomGrid(CreateBottomGridDto bottomGridDto)
        {
            string query = "insert into BottomGrid (Icon,Title,Description) values (@Icon,@Title,@Description)";
            var paramaters = new DynamicParameters();
            paramaters.Add("@Icon", bottomGridDto.Icon);
            paramaters.Add("@Title", bottomGridDto.Title);
            paramaters.Add("@Description", bottomGridDto.Description);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, paramaters);

            }
        }

        public async Task DeleteBottomGrid(int id)
        {
            string query = "Delete from BottomGrid Where BottomGridID=@BottomGridID";
            var paramaters = new DynamicParameters();
            paramaters.Add("@BottomGridID", id);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, paramaters);
            }
        }

        public async Task<List<ResultBottomGridDto>> GetAllBottomGridAsync()
        {
            string query = "Select * from BottomGrid";

            try
            {
                using (var connection = _context.CreateConnection())
                {
                    var values = await connection.QueryAsync<ResultBottomGridDto>(query);
                    return values.ToList();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                throw;
            }
        }

        public async Task<GetBottomGridDto> GetBottomGrid(int id)
        {
            string query = " Select * from BottomGrid Where BottomGridID=@BottomGridID";
            var paramaters = new DynamicParameters();
            paramaters.Add("@BottomGridID", id);
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryFirstOrDefaultAsync<GetBottomGridDto>(query, paramaters);
                return values;

            }
        }

        public async Task UpdateBottomGrid(UpdateBottomGridDto bottomGridDto)
        {
            string query = "Update BottomGrid Set Icon=@Icon, Title=@Title,Description =@Description where BottomGridID=@BottomGridID";
            var paramaters = new DynamicParameters();
            paramaters.Add("@Icon", bottomGridDto.Icon);
            paramaters.Add("@Title", bottomGridDto.Title);
            paramaters.Add("@Description", bottomGridDto.Description);
            paramaters.Add("@BottomGridID", bottomGridDto.BottomGridID);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, paramaters);
            }
        }

       
    }
}
