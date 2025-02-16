using RealEstate_Dapper_API.Dtos.TestimonialDtos;

namespace RealEstate_Dapper_API.Repositories.TestimonialRepository
{
    public interface ITestimonialRepository
    {
        Task<List<ResutlTestimonialDto>> GetAllTestimonialAsync();
    }
}
