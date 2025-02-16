using Dapper;
using RealEstate_Dapper_API.Properties.Models.DapperContext;

namespace RealEstate_Dapper_API.Repositories.StatistikRepostiory
{
    public class StatistikRepository : IStatistikRepository
    {
        private readonly Context _context;

        public StatistikRepository(Context context)
        {
            _context = context;
        }
        public  int ActiveCategoryCount()
        {
            string query = "Select Count(*) from Category where CategoryStatus=1";

            try
            {
                using (var connection = _context.CreateConnection())
                {
                    var values =  connection.QueryFirstOrDefault<int>(query);
                    return values;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                throw;
            }
        }

        public int ActiveEmployeeCount()
        {
            string query = "Select Count(*) from Employee where Status=1";

            try
            {
                using (var connection = _context.CreateConnection())
                {
                    var values = connection.QueryFirstOrDefault<int>(query);
                    return values;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                throw;
            }
        }

        public int ApartmentCount()
        {
            string query = "Select Count(*) from Product where Title like 'Daire'";

            try
            {
                using (var connection = _context.CreateConnection())
                {
                    var values = connection.QueryFirstOrDefault<int>(query);
                    return values;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                throw;
            }
        }

        public int AvaregeRoomCount()
        {
            string query = "Select Avg(RoomCount) from ProductDetails ";

            try
            {
                using (var connection = _context.CreateConnection())
                {
                    var values = connection.QueryFirstOrDefault<int>(query);
                    return values;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                throw;
            }
        }

        public decimal AverageProductPriceByRent()
        {
            string query = "Select Avg(Price) From Product where Type='Kiralık'";

            try
            {
                using (var connection = _context.CreateConnection())
                {
                    var values = connection.QueryFirstOrDefault<decimal>(query);
                    return values;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                throw;
            }
        }

        public decimal AverageProductPriceBySale()
        {
            string query = "Select Avg(Price) From Product where Type='Satılık'";

            try
            {
                using (var connection = _context.CreateConnection())
                {
                    var values = connection.QueryFirstOrDefault<decimal>(query);
                    return values;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                throw;
            }
        }

        public int CategoryCount()
        {
            string query = "Select Count(*) from Category";

            try
            {
                using (var connection = _context.CreateConnection())
                {
                    var values = connection.QueryFirstOrDefault<int>(query);
                    return values;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                throw;
            }
        }

        public string CategoryNameByMaxProduction()
        {
            string query = "Select top(1) CategoryName,Count(*) From Product inner join Category on Product.ProductCategory=Category.CategoryID Group By CategoryName order by Count(*) Desc";

            try
            {
                using (var connection = _context.CreateConnection())
                {
                    var values = connection.QueryFirstOrDefault<string >(query);
                    return values;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                throw;
            }
        }

        public string CityNameByMaxProductCount()
        {
            string query = "Select top(1) City,Count(*) as 'product_count' From Product Group By City order by product_count Desc";

            try
            {
                using (var connection = _context.CreateConnection())
                {
                    var values = connection.QueryFirstOrDefault<string>(query);
                    return values;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                throw;
            }
        }

        public int DifferentCityCount()
        {
            string query = "Select Count(Distinct(City)) from Product";

            try
            {
                using (var connection = _context.CreateConnection())
                {
                    var values = connection.QueryFirstOrDefault<int>(query);
                    return values;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                throw;
            }
        }

        public string EmployeeNameByMaxProduction()
        {
            string query = "Select EmployeeName,Count(*) 'product_count' from Product Inner join Employee On Product.EmployeeID=Employee.EmployeeID group by EmployeeName Order By product_count Desc";

            try
            {
                using (var connection = _context.CreateConnection())
                {
                    var values = connection.QueryFirstOrDefault<string>(query);
                    return values;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                throw;
            }
        }

        public decimal LastProductPrice()
        {

            string query = "Select * from Product Order By ProductID Desc";

            try
            {
                using (var connection = _context.CreateConnection())
                {
                    var values = connection.QueryFirstOrDefault<decimal>(query);
                    return values;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                throw;
            }
        }

        public string NewestBuildingYear()
        {
            string query = "Select top(1) BuildYear from ProductDetails Order By BuildYear Desc";

            try
            {
                using (var connection = _context.CreateConnection())
                {
                    var values = connection.QueryFirstOrDefault<string>(query);
                    return values;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                throw;
            }
        }

        public string OldestBuildingYear()
        {
            string query = "Select top(1) BuildYear from ProductDetails Order By BuildYear Asc";

            try
            {
                using (var connection = _context.CreateConnection())
                {
                    var values = connection.QueryFirstOrDefault<string>(query);
                    return values;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                throw;
            }
        }

        public int PassiveCategoryCount()
        {
            string query = "Select Count(*) from Category where CategoryStatus=1";
            try
            {
                using (var connection = _context.CreateConnection())
                {
                    var values = connection.QueryFirstOrDefault<int>(query);
                    return values;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                throw;
            }
        }

        public int ProductCount()
        {
            string query = "Select Count(*) from Product";

            try
            {
                using (var connection = _context.CreateConnection())
                {
                    var values = connection.QueryFirstOrDefault<int>(query);
                    return values;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                throw;
            }
        }
    }
}
