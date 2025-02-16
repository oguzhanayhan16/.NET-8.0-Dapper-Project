using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace RealEstate_Dapper_UI.ViewComponents.Dashboard
{
    public class _StatistiksComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _StatistiksComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            #region İstatistik1 -toplam ilan sayisi
            var client1 = _httpClientFactory.CreateClient();
            var responseMessage1 = await client1.GetAsync("https://localhost:44300/api/Statistik/ProductCount");
            var jsonData1 = await responseMessage1.Content.ReadAsStringAsync();
            ViewBag.productCount = jsonData1;
            #endregion

            #region İstatistik2
            var client2 = _httpClientFactory.CreateClient();
            var responseMessage2 = await client2.GetAsync("https://localhost:44300/api/Statistik/EmployeeNameByMaxProduction");
            var jsonData2 = await responseMessage2.Content.ReadAsStringAsync();
            ViewBag.employeeNameByMaxProduction = jsonData2;
            #endregion

            #region İstatistik3
            var client3 = _httpClientFactory.CreateClient();
            var responseMessage3 = await client3.GetAsync("https://localhost:44300/api/Statistik/DifferentCityCount");
            var jsonData3 = await responseMessage3.Content.ReadAsStringAsync();
            ViewBag.differentCity = jsonData3;
            #endregion

            #region İstatistik4
            var client4 = _httpClientFactory.CreateClient();
            var responseMessage4 = await client4.GetAsync("https://localhost:44300/api/Statistik/AverageProductPriceByRent");
            var jsonData4 = await responseMessage4.Content.ReadAsStringAsync();
            ViewBag.avarageRent = jsonData4;
            #endregion
            return View();

        }
    }
}
