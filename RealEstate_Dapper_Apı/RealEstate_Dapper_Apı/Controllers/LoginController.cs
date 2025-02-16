using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_API.Dtos.LoginDto;
using RealEstate_Dapper_API.Properties.Models.DapperContext;
using RealEstate_Dapper_API.Tools;

namespace RealEstate_Dapper_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {

        private readonly Context _context;

        public LoginController(Context context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> SignIn(CreateLoginDto loginDto)
        {
            string query = "Select * from Appuser Where Username=@username and Password = @password";
            string query2 = "Select UserId from Appuser Where Username=@username and Password = @password";
            var parameters = new DynamicParameters();
            parameters.Add("@username", loginDto.UserName);
            parameters.Add("@password", loginDto.Password);

            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryFirstOrDefaultAsync<CreateLoginDto>(query,parameters);
                var values2 = await connection.QueryFirstAsync<GetAppUserIdDto>(query2,parameters);
                if (values != null) {

                    GetCheckAppUserViewMoel model = new GetCheckAppUserViewMoel();
                    model.Username = values.UserName;
                    model.Id=values2.UserId;
                    var token = JwtTokenGenerator.GenerateToken(model);
                    return Ok(token);
                }
                else
                {
                    return Ok("Başarısız");
                }
            }
        }
    }
}
