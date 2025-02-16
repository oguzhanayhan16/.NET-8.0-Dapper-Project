using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RealEstate_Dapper_UI.Dtos.EstateAgenDtos;

namespace RealEstate_Dapper_UI.ViewComponents.EstateAgent
{
    public class _EstateAgentNavbarComponentPartial:ViewComponent
    {
        

        public IViewComponentResult Invoke()
        {
           
            return View();

        }
    }
}
