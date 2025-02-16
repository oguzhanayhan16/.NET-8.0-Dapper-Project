using Dapper;
using RealEstate_Dapper_API.Dtos.ContactDtos;
using RealEstate_Dapper_API.Properties.Models.DapperContext;

namespace RealEstate_Dapper_API.Repositories.ContactRepository
{
    public class ContactRepository : IContactRepository
    {
        private readonly Context _context;

        public ContactRepository(Context context)
        {
            _context = context;
        }
        public Task CreateContact(CreateContactDto ContactDto)
        {
            throw new NotImplementedException();
        }

        public Task DeleteContact(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<ResultContactDto>> GetAllContactAsync()
        {
            throw new NotImplementedException();
        }

        public Task<GetByIDContactDto> GetContact(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Last4ContactResultDto>> GetLast4ContactAsync()
        {
            string query = "Select TOP(4) * from Contact order by ContactID Desc";

            try
            {
                using (var connection = _context.CreateConnection())
                {
                    var values = await connection.QueryAsync<Last4ContactResultDto>(query);
                    return values.ToList();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                throw;
            };
        }
    }
}
