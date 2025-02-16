using Dapper;
using RealEstate_Dapper_API.Dtos.PropertyAmenityDtos;
using RealEstate_Dapper_API.Properties.Models.DapperContext;

namespace RealEstate_Dapper_API.Repositories.PropertyAmenityRepository
{
    public class PropertyAmenityRepository : IPropertyAmenityRepository
    {
        private readonly Context _context;

        public PropertyAmenityRepository(Context context)
        {
            _context = context;
        }

      
        public async Task<List<ResultPropertyAmenityByStatusTrueDto>> ResultPropertyAmenityByStatusTrue(int id)
        {
            string query = "Select PropertyAmenityId,Title From PropertyAmenity Inner Jıin Amenity On Amenity.AmenityId = PropertyAmenity.AmenityId Where PropertyId =@id and Status=1";
            var paramaters = new DynamicParameters();
            paramaters.Add("@id", id);
            using (var connection = _context.CreateConnection())
            {
               var values= await connection.QueryAsync<ResultPropertyAmenityByStatusTrueDto>(query, paramaters);
                return values.ToList();
            }
        }
    }
}
