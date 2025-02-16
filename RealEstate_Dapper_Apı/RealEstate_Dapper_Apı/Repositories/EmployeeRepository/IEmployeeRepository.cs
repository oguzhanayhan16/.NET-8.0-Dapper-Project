using RealEstate_Dapper_API.Dtos.EmployeeDtos;

namespace RealEstate_Dapper_API.Repositories.EmployeeRepository
{
    public interface IEmployeeRepository
    {
        Task<List<ResultEmployeeDto>> GetAllEmployeeAsync();
        Task CreateEmployee(CreateEmployeeDto EmployeeDto);
        Task DeleteEmployee(int id);

        Task UpdateEmployee(UpdateEmployeeDto EmployeeDto);

        Task<GetByIDEmployeeDto> GetEmployee(int id);
    }
}
