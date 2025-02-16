using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_UI.Services;

namespace RealEstate_Dapper_UI.ViewComponents.EstateAgent
{
    public class _EstateAgentDashboardStatisticComponentPartial:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private ILoginService loginService;
        public _EstateAgentDashboardStatisticComponentPartial(IHttpClientFactory httpClientFactory, ILoginService loginService)
        {
            _httpClientFactory = httpClientFactory;
            this.loginService = loginService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var id = loginService.GetUserId;
            #region İstatistik1 -toplam ilan sayisi
            var client1 = _httpClientFactory.CreateClient();
            var responseMessage1 = await client1.GetAsync("https://localhost:44300/api/EstateAgentDashboardStatistic/ProductCount");
            var jsonData1 = await responseMessage1.Content.ReadAsStringAsync();
            ViewBag.productCount = jsonData1;
            #endregion

            #region Emlakçının Toplam İlan Sayısı
            var client2 = _httpClientFactory.CreateClient();
            var responseMessage2 = await client2.GetAsync("https://localhost:44300/api/EstateAgentDashboardStatistic/ProductCountByStatusTrue?id="+id);
            var jsonData2 = await responseMessage2.Content.ReadAsStringAsync();
            ViewBag.employeeByProduction = jsonData2;
            #endregion

            #region Aktif İlan Sayısı
            var client3 = _httpClientFactory.CreateClient();
            var responseMessage3 = await client3.GetAsync("https://localhost:44300/api/EstateAgentDashboardStatistic/ProductCountByStatusTrue?id=" + id);
            var jsonData3 = await responseMessage3.Content.ReadAsStringAsync();
            ViewBag.productCountTrue = jsonData3;
            #endregion

            #region İstatistik4
            var client4 = _httpClientFactory.CreateClient();
            var responseMessage4 = await client4.GetAsync("https://localhost:44300/api/EstateAgentDashboardStatistic/ProductCountByStatusFalse?id=" + id);
            var jsonData4 = await responseMessage4.Content.ReadAsStringAsync();
            ViewBag.productCountFalse = jsonData4;
            #endregion
            return View();

        }
    }
}
