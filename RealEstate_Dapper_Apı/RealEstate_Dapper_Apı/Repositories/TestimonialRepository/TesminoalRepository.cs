using Dapper;
using RealEstate_Dapper_API.Dtos.PopulerLocationDtos;
using RealEstate_Dapper_API.Dtos.TestimonialDtos;
using RealEstate_Dapper_API.Properties.Models.DapperContext;

namespace RealEstate_Dapper_API.Repositories.TestimonialRepository
{
    public class TesminoalRepository:ITestimonialRepository
    {
        private readonly Context _context;

        public TesminoalRepository(Context context)
        {
            _context = context;
        }

        public async Task<List<ResutlTestimonialDto>> GetAllTestimonialAsync()
        {
            string query = "Select * from Testimonial";

            try
            {
                using (var connection = _context.CreateConnection())
                {
                    var values = await connection.QueryAsync<ResutlTestimonialDto>(query);
                    return values.ToList();
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
