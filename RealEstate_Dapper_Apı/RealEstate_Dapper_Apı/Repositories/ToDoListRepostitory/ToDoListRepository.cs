using Dapper;
using RealEstate_Dapper_API.Dtos.ToDoListDtos;
using RealEstate_Dapper_API.Properties.Models.DapperContext;

namespace RealEstate_Dapper_API.Repositories.ToDoListRepostitory
{
    public class ToDoListRepository : IToDoListRepository
    {
        private readonly Context _context;

        public ToDoListRepository(Context context)
        {
            _context = context;
        }
        public Task CreateToDoList(CreateToDoListDto ToDoListDto)
        {
            throw new NotImplementedException();
        }

        public Task DeleteToDoList(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<ResultToDoListDto>> GetAllToDoListAsync()
        {
            string query = "Select * from ToDoList";

            try
            {
                using (var connection = _context.CreateConnection())
                {
                    var values = await connection.QueryAsync<ResultToDoListDto>(query);
                    return values.ToList();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                throw;
            }
        }

        public Task<GetByIDToDoListDto> GetToDoList(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateToDoList(UpdateToDoListDto ToDoListDto)
        {
            throw new NotImplementedException();
        }
    }
}
