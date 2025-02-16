using Dapper;
using RealEstate_Dapper_API.Dtos.AppUserDtos;
using RealEstate_Dapper_API.Properties.Models.DapperContext;

namespace RealEstate_Dapper_API.Repositories.AppUserRepository
{
    public class AppUserRepository : IAppUserRepository
    {
        private readonly Context _context;

        public AppUserRepository(Context context)
        {
            _context = context;
        }

        public async Task<GetAppUserByProductIdDto> GetAppUserById(int id)
        {
            string query = "SELECT UserId, Name, Email, PhoneNumber, UserImageUrl FROM AppUser WHERE UserId = @id";
            var parameters = new DynamicParameters();
            parameters.Add("@id", id);

            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryFirstOrDefaultAsync<GetAppUserByProductIdDto>(query, parameters);
                return values;
            }
        }

    }
}
