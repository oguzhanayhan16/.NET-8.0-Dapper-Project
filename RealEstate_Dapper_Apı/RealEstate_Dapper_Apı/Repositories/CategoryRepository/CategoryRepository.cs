using RealEstate_Dapper_API.Dtos.CategoryDtos;
using RealEstate_Dapper_API.Properties.Models.DapperContext;
using Dapper;
namespace RealEstate_Dapper_API.Repositories.CategoryRepository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly Context _context;

        public CategoryRepository(Context context)
        {
            _context = context;
        }

        public async Task CreateCategory(CreateCategoryDto categoryDto)
        {
            string query = "insert into Category (CategoryName,CategoryStatus)values (@categoryName,@categoryStatus)";
            var paramaters = new DynamicParameters();
            paramaters.Add("@categoryName", categoryDto.CategoryName);
            paramaters.Add("@categoryStatus",true);
            using (var connection =_context.CreateConnection())
            {
                await connection.ExecuteAsync(query, paramaters);
            }
        }

        public async Task DeleteCategory(int id)
        {
            string query = "Delete from Category Where CategoryID=@categoryID";
            var paramaters = new DynamicParameters();
            paramaters.Add("@categoryID", id);
            using (var connection =  _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, paramaters);
            }

        }

        public async Task<List<ResultCategoryDto>> GetAllCategoryAsync()
        {
            string query = "Select * from Category";

            try
            {
                using (var connection = _context.CreateConnection())
                {
                    var values = await connection.QueryAsync<ResultCategoryDto>(query);
                    return values.ToList();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                throw;
            }
        }

        public async Task<GetByIDCategoryDto> GetCategory(int id)
        {
            string query = " Select * from Category Where CategoryID=@categoryID";
            var paramaters = new DynamicParameters();
            paramaters.Add("@categoryID", id);
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryFirstOrDefaultAsync<GetByIDCategoryDto>(query, paramaters);
                return values;

            }

        }

        public async Task UpdateCategory(UpdateCategoryDto categoryDto)
        {
            string query = "Update Category Set CategoryName=@categoryName, CategoryStatus=@categoryStatus where CategoryID=@categoryID";
            var parameters = new DynamicParameters();
            parameters.Add("@categoryName", categoryDto.CategoryName);
            parameters.Add("@categoryStatus", categoryDto.CategoryStatus);
            parameters.Add("@CategoryID", categoryDto.CategoryID);

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }
    }
    }

