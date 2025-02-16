using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_API.Repositories.AppUserRepository;

namespace RealEstate_Dapper_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppUserController : ControllerBase
    {
        private readonly IAppUserRepository _appUserRepository;

        public AppUserController(IAppUserRepository appUserRepository)
        {
            _appUserRepository = appUserRepository;
        }
        [HttpGet]
        public async Task<IActionResult>  GetAppUserByProductId(int id)
        {
            var values = await _appUserRepository.GetAppUserById(id);
            return Ok(values);
        }
    }
}
