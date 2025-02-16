using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_API.Repositories.BottomGridRepository;
using RealEstate_Dapper_API.Repositories.TestimonialRepository;

namespace RealEstate_Dapper_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestimonialController : ControllerBase
    {
        private readonly ITestimonialRepository _testimonialRepository;

        public TestimonialController(ITestimonialRepository testimonialRepository)
        {
            _testimonialRepository = testimonialRepository;
        }
        [HttpGet]
        public async Task<IActionResult> TestimonialList()
        {
            var values = await _testimonialRepository.GetAllTestimonialAsync();
            return Ok(values);
        }
    }
}
