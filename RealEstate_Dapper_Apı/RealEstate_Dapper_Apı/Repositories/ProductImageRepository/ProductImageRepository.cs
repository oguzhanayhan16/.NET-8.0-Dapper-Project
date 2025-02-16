using Dapper;
using RealEstate_Dapper_API.Dtos.ProductImageDto;
using RealEstate_Dapper_API.Properties.Models.DapperContext;

namespace RealEstate_Dapper_API.Repositories.ProductImageRepository
{
    public class ProductImageRepository : IProductImageRepository
    {

        private readonly Context _context;

        public ProductImageRepository(Context context)
        {
            _context = context;
        }
        public async Task<List<GetProductImageByProductIdDto>> GetProductImageById(int id)
        {
            string query = "Select * from ProductImage Where ProductId = @id";

            var paramaters = new DynamicParameters();
            paramaters.Add("@id", id);
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<GetProductImageByProductIdDto>(query, paramaters);
                return values.ToList();
            }
        }
    }
}
