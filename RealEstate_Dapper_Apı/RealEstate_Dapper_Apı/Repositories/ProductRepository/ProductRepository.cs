using System.Reflection.Metadata;
using Dapper;
using RealEstate_Dapper_API.Dtos.CategoryDtos;
using RealEstate_Dapper_API.Dtos.ProductDetailDtos;
using RealEstate_Dapper_API.Dtos.ProductDtos;
using RealEstate_Dapper_API.Properties.Models.DapperContext;

namespace RealEstate_Dapper_API.Repositories.ProductRepository
{
    public class ProductRepository : IProductRepository
    {
        private readonly Context _context;

        public ProductRepository(Context context)
        {
            _context = context;
        }

        public async Task<List<ResultProductDto>> GetAllProductAsync()
        {
            string query = "Select * from Product";

          
                using (var connection = _context.CreateConnection())
                {
                    var values = await connection.QueryAsync<ResultProductDto>(query);
                    return values.ToList();
                }
            
          
        }

        public async Task<List<ResultProductWtihCategoryDto>> GetAllProductWithCategory()
        {
            string query = "Select ProductID,Title,Price,City,District,CategoryName,CoverImage,Type,Address,DealOfTheDay,SlugUrl from Product inner join Category on Product.ProductCategory = Category.CategoryID";


            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultProductWtihCategoryDto>(query);
                return values.ToList();
            }
        }

        public async Task<List<ResultLast5ProductDto>> GetLast5ProductAsync()
        {
            string query = "Select Top(5) ProductID,Title,Price,City,District,ProductCategory,CategoryName,AdvertisementDate from Product Inner Join Category on Product.ProductCategory=Category.CategoryID where Type='Kiralık' Order By ProductID Desc";


            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultLast5ProductDto>(query);
                return values.ToList();
            }

        }

        public async Task<List<ResultProductAdvertListWitchCategoryByEmployeeDto>> GetProductListAdvertListByEmpoleeAsyncByTrue(int id)
        {
            string query = "Select ProductID,Title,Price,City,District,CategoryName,CoverImage,Type,Address,DealOfTheDay from Product inner join Category on Product.ProductCategory = Category.CategoryID where AppUserID = @employeeId and ProductStatus=1";

            var paramaters = new DynamicParameters();
            paramaters.Add("@employeeId", id);
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultProductAdvertListWitchCategoryByEmployeeDto>(query,paramaters);
                return values.ToList();
            }
        }
        public async Task<List<ResultProductAdvertListWitchCategoryByEmployeeDto>> GetProductListAdvertListByEmpoleeAsyncByFalse(int id)
        {
            string query = "Select ProductID,Title,Price,City,District,CategoryName,CoverImage,Type,Address,DealOfTheDay from Product inner join Category on Product.ProductCategory = Category.CategoryID where AppUserID = @employeeId and ProductStatus=0";

            var paramaters = new DynamicParameters();
            paramaters.Add("@employeeId", id);
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultProductAdvertListWitchCategoryByEmployeeDto>(query, paramaters);
                return values.ToList();
            }
        }

        public async Task ProductDealOfTheDayStatusChangeFalse(int id)
        {
            string query = "Update Product Set DealOfTheDay=@DealOfTheDay where ProductID=@ProductID";
            var paramaters = new DynamicParameters();
            paramaters.Add("@DealOfTheDay", 0);
            paramaters.Add("@ProductID", id);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, paramaters);
            }
        }

        public async Task ProductDealOfTheDayStatusChangeTrue(int id)
        {
            string query = "Update Product Set DealOfTheDay=@DealOfTheDay where ProductID=@ProductID";
            var paramaters = new DynamicParameters();
            paramaters.Add("@DealOfTheDay", 1);
            paramaters.Add("@ProductID", id);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, paramaters);
            }
        }

        public async Task CreateProduct(CreateProductDto createProductDto)
        {
            string query = "insert into Product (Title,Price,City,District,CoverImage,Address,Description,Type,DealOfTheDay,AdvertisementDate,ProductStatus,ProductCategory,AppUserID) values (@Title,@Price,@City,@District,@CoverImage,@Address,@Description,@Type,@DealOfTheDay,@AdvertisementDate,@ProductStatus,@ProductCategory,@EmployeeID)";
            var parameters = new DynamicParameters();
            parameters.Add("@Title", createProductDto.Title);
            parameters.Add("@Price", createProductDto.Price);
            parameters.Add("@City", createProductDto.City);
            parameters.Add("@District", createProductDto.District);
            parameters.Add("@CoverImage", createProductDto.CoverImage);
            parameters.Add("@Address", createProductDto.Address);
            parameters.Add("@Description", createProductDto.Description);
            parameters.Add("@Type", createProductDto.Type);
            parameters.Add("@DealOfTheDay", createProductDto.DealOfTheDay);
            parameters.Add("@AdvertisementDate", createProductDto.AdvertisementDate);
            parameters.Add("@ProductStatus", createProductDto.ProductStatus);
            parameters.Add("@ProductCategory", createProductDto.ProductCategory);
            parameters.Add("@EmployeeID", createProductDto.EmployeeID);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task<GetProductByIdDto> GetProductById(int id)
        {
            string query = "Select ProductID,AdvertisementDate,Title,Price,City,District,CategoryName,CoverImage,Type,Address,DealOfTheDay,SlugUrl from Product inner join Category on Product.ProductCategory = Category.CategoryID where ProductID =@id";
            var parameters = new DynamicParameters();
            parameters.Add("@id", id);

            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<GetProductByIdDto>(query,parameters);
                return values.FirstOrDefault();
            }
        }

        public async Task<GetProudctDetailByIdDto> GetProductDetailByProductId(int id)
        {
            string query = "Select * From ProductDetails Where ProductId = @id";

            var paramaters = new DynamicParameters();
            paramaters.Add("@id", id);
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<GetProudctDetailByIdDto>(query,paramaters);
                return values.FirstOrDefault();
            }
        }

        public async Task<List<ResulProductWithSearchListDto>> ResultProductWithSearchList(string searchKeyValue, int propertyCategoryId, string city)
        {
            string query = "Select * From Product Where Title like '%" + searchKeyValue + "%' And ProductCategory=@propertyCategoryId And City=@city";
            var parameters = new DynamicParameters();
            //   parameters.Add("@searchKeyValue", searchKeyValue);
            parameters.Add("@propertyCategoryId", propertyCategoryId);
            parameters.Add("@city", city);
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResulProductWithSearchListDto>(query, parameters);
                return values.ToList();
            }
        }

        public async Task<List<ResultProductWtihCategoryDto>> GetProductByealOfTheDayTrue()
        {
            string query = "Select ProductID,Title,Price,City,District,CategoryName,CoverImage,Type,Address,DealOfTheDay from Product inner join Category on Product.ProductCategory = Category.CategoryID where DealOfTheDay=1";


            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultProductWtihCategoryDto>(query);
                return values.ToList();
            }
        }

        public async Task<List<ResultLast5ProductDto>> GetLast3ProductAsync()
        {
            string query = "Select Top(3) ProductID,Title,Price,City,District,ProductCategory,CategoryName,AdvertisementDate,CoverImage,Description from Product Inner Join Category on Product.ProductCategory=Category.CategoryID  Order By ProductID Desc";


            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultLast5ProductDto>(query);
                return values.ToList();
            }
        }
    }
}
