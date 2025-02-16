using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RealEstate_Dapper_UI.Dtos.EstateAgenDtos;
using RealEstate_Dapper_UI.Dtos.ProductDtos;
using RealEstate_Dapper_UI.Services;

namespace RealEstate_Dapper_UI.ViewComponents.EstateAgent
{
    public class _EstateAgentLast5ProductComponentPartial:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private ILoginService loginService;
        public _EstateAgentLast5ProductComponentPartial(IHttpClientFactory httpClientFactory, ILoginService loginService)
        {
            _httpClientFactory = httpClientFactory;
            this.loginService = loginService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var id = loginService.GetUserId;
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:44300/api/EstateAgentLastProduct?id="+id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultLast5ProductDto>>(jsonData);
                return View(values);

            }
            return View();

        }
    }
}
