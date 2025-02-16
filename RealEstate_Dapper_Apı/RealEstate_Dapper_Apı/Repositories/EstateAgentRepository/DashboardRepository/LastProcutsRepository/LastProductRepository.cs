using Dapper;
using RealEstate_Dapper_API.Dtos.ProductDtos;
using RealEstate_Dapper_API.Properties.Models.DapperContext;

namespace RealEstate_Dapper_API.Repositories.EstateAgentRepository.DashboardRepository.LastProcutsRepository
{
    public class LastProductRepository : ILastProductRepository
    {
        private readonly Context _context;

        public LastProductRepository(Context context)
        {
            _context = context;
        }
        public async Task<List<ResultLast5ProductDto>> GetLast5Product(int id)
        {
            string query = "Select Top(5) ProductID,Title,Price,City,District,ProductCategory,CategoryName,AdvertisementDate from Product Inner Join Category on Product.ProductCategory=Category.CategoryID where AppUserID = @EmployeeId Order By ProductID Desc";
            var paramaters = new DynamicParameters();
            paramaters.Add("@EmployeeId", id);

            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultLast5ProductDto>(query,paramaters);
                return values.ToList();
            }
        }
    }
}
