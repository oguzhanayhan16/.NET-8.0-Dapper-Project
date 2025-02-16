using Dapper;
using RealEstate_Dapper_API.Dtos.CategoryDtos;
using RealEstate_Dapper_API.Dtos.WhoWeAreDetailDtos;
using RealEstate_Dapper_API.Properties.Models.DapperContext;

namespace RealEstate_Dapper_API.Repositories.WhoWeAreRepository
{
    public class WhoWeAreRepository : IWhoWeAreRepostiyory
    {
        private readonly Context _context;

        public WhoWeAreRepository(Context context)
        {
            _context = context;
        }

        public async Task CreateWhoWeAre(CreateWhoWeAreDetailDto createWhoWeAre)
        {
            string query = "insert into WhoWeAreDetail (Title,SubTitle,Description1,Description2) values (@title,@SubTitle,@Description1,@Description2)";
            var paramaters = new DynamicParameters();
            paramaters.Add("@title", createWhoWeAre.Title);
            paramaters.Add("@SubTitle", createWhoWeAre.SubTitle);
            paramaters.Add("@Description1", createWhoWeAre.Description1);
            paramaters.Add("@Description2", createWhoWeAre.Description2);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, paramaters);

            }
        }

        public async Task DeleteWhoWeAre(int id)
        {
            string query = "Delete from WhoWeAreDetail Where WhoWeAreDetailID=@WhoWeAreDetailID";
            var paramaters = new DynamicParameters();
            paramaters.Add("@WhoWeAreDetailID", id);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, paramaters);
            }
        }

        public async Task<List<ResultWhoWeAreDetailDto>> GetAllWhoWeAreAsync()
        {
            string query = "Select * from WhoWeAreDetail";

            try
            {
                using (var connection = _context.CreateConnection())
                {
                    var values = await connection.QueryAsync<ResultWhoWeAreDetailDto>(query);
                    return values.ToList();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                throw;
            }
        }

        public async Task<GetByIDWhoWeAreDto> GetWhoWeAre(int id)
        {
            string query = " Select * from WhoWeAreDetail Where WhoWeAreDetailID=@WhoWeAreDetailID";
            var paramaters = new DynamicParameters();
            paramaters.Add("@WhoWeAreDetailID", id);
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryFirstOrDefaultAsync<GetByIDWhoWeAreDto>(query, paramaters);
                return values;

            }
        }

        public async Task UpdateWhoWeAre(UpdateWhoWeAreDetailDto updateWhoWeAreDto)
        {
            string query = "Update WhoWeAreDetail Set Title=@Title, SubTitle=@SubTitle,Description1=@Description1,Description2=@Description2 where WhoWeAreDetailID=@WhoWeAreDetailID";
            var paramaters = new DynamicParameters();
            paramaters.Add("@Title", updateWhoWeAreDto.Title);
            paramaters.Add("@SubTitle", updateWhoWeAreDto.SubTitle);
            paramaters.Add("@Description1", updateWhoWeAreDto.Description1);
            paramaters.Add("@Description2", updateWhoWeAreDto.Description2);
            paramaters.Add("@WhoWeAreDetailID", updateWhoWeAreDto.WhoWeAreDetailID);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, paramaters);
            }
        }
    }
}
