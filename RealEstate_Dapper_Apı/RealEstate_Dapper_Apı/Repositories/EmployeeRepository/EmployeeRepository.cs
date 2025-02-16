using Dapper;
using RealEstate_Dapper_API.Dtos.CategoryDtos;
using RealEstate_Dapper_API.Dtos.EmployeeDtos;
using RealEstate_Dapper_API.Properties.Models.DapperContext;
using System.Reflection.Metadata;

namespace RealEstate_Dapper_API.Repositories.EmployeeRepository
{
    public class EmployeeRepository:IEmployeeRepository
    {
        private readonly Context _context;

        public EmployeeRepository(Context context)
        {
            _context = context;
        }

        public async Task CreateEmployee(CreateEmployeeDto EmployeeDto)
        {
            string query = "insert into Employee (EmployeeName,Title,Mail,PhoneNumber,ImageUrl,Status)values (@Name,@Title,@Mail,@PhoneNumber,@ImageUrl,@Status)";
            var paramaters = new DynamicParameters();
            paramaters.Add("@Name", EmployeeDto.EmployeeName);
            paramaters.Add("@Title", EmployeeDto.Title);
            paramaters.Add("@Mail", EmployeeDto.Mail);
            paramaters.Add("@PhoneNumber", EmployeeDto.PhoneNumber);
            paramaters.Add("@ImageUrl", EmployeeDto.ImageUrl);
            paramaters.Add("@Status", true);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, paramaters);
            }
        }

        public async Task DeleteEmployee(int id)
        {
            string query = "Delete from Employee Where EmployeeID=@EmployeeID";
            var paramaters = new DynamicParameters();
            paramaters.Add("@EmployeeID", id);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, paramaters);
            }
        }

        public async Task<List<ResultEmployeeDto>> GetAllEmployeeAsync()
        {
            string query = "Select * from Employee";

            try
            {
                using (var connection = _context.CreateConnection())
                {
                    var values = await connection.QueryAsync<ResultEmployeeDto>(query);
                    return values.ToList();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                throw;
            }
        }

        public async Task<GetByIDEmployeeDto> GetEmployee(int id)
        {
            string query = " Select * from Employee Where EmployeeID=@EmployeeID";
            var paramaters = new DynamicParameters();
            paramaters.Add("@EmployeeID", id);
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryFirstOrDefaultAsync<GetByIDEmployeeDto>(query, paramaters);
                return values;

            }
        }

        public async Task UpdateEmployee(UpdateEmployeeDto EmployeeDto)
        {
            string query = "Update Employee Set EmployeeName=@Name, Title=@Title,Mail=@Mail,PhoneNumber=@PhoneNumber,ImageUrl=@imageUrl,Status=@Status where EmployeeID=@EmployeeID";
            var parameters = new DynamicParameters();
            parameters.Add("@Name", EmployeeDto.EmployeeName);
            parameters.Add("@Title", EmployeeDto.Title);
            parameters.Add("@Mail", EmployeeDto.Mail);
            parameters.Add("@PhoneNumber", EmployeeDto.PhoneNumber);
            parameters.Add("@imageUrl", EmployeeDto.ImageUrl);
            parameters.Add("@Status", EmployeeDto.Status);
            parameters.Add("@EmployeeID", EmployeeDto.EmployeeID);

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }
    }
}
