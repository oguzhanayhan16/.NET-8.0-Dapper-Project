using System.Security.Claims;

namespace RealEstate_Dapper_UI.Services
{
    public class LoginService : ILoginService
    {

        private readonly IHttpContextAccessor _HttpContextAccessor;

        public LoginService(IHttpContextAccessor HttpContextAccessor)
        {
            _HttpContextAccessor = HttpContextAccessor;
        }
        public string GetUserId => _HttpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;

    }
}
