using Microsoft.AspNetCore.Mvc;

namespace RealEstate_Dapper_UI.Controllers
{
    public class StatistikController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public StatistikController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IActionResult> Index()
        {
            #region İstatistik1
            var client =_httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:44300/api/Statistik/ActiveCategoryCount");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            ViewBag.activeCategoryCount = jsonData;
            #endregion
            #region İstatistik2
            var client2 = _httpClientFactory.CreateClient();
            var responseMessage2 = await client2.GetAsync("https://localhost:44300/api/Statistik/ActiveEmployeeCount");
            var jsonData2 = await responseMessage2.Content.ReadAsStringAsync();
            ViewBag.activeEmployeeCount = jsonData2;
            #endregion
            #region İstatistik3
            var client3 = _httpClientFactory.CreateClient();
            var responseMessage3 = await client3.GetAsync("https://localhost:44300/api/Statistik/ApartmentCount");
            var jsonData3 = await responseMessage3.Content.ReadAsStringAsync();
            ViewBag.apartmanCount = jsonData3;
            #endregion
            #region İstatistik4
            var client4 = _httpClientFactory.CreateClient();
            var responseMessage4 = await client4.GetAsync("https://localhost:44300/api/Statistik/AverageProductPriceByRent");
            var jsonData4 = await responseMessage4.Content.ReadAsStringAsync();
            ViewBag.avarageRent = jsonData4;
            #endregion
            #region İstatistik5
            var client5 = _httpClientFactory.CreateClient();
            var responseMessage5 = await client5.GetAsync("https://localhost:44300/api/Statistik/AverageProductPriceBySale");
            var jsonData5 = await responseMessage5.Content.ReadAsStringAsync();
            ViewBag.avarageSale = jsonData5;
            #endregion
            #region İstatistik6
            var client6 = _httpClientFactory.CreateClient();
            var responseMessage6 = await client6.GetAsync("https://localhost:44300/api/Statistik/AvaregeRoomCount");
            var jsonData6 = await responseMessage6.Content.ReadAsStringAsync();
            ViewBag.avarageRoomCount = jsonData6;
            #endregion
            #region İstatistik7
            var client7 = _httpClientFactory.CreateClient();
            var responseMessage7 = await client7.GetAsync("https://localhost:44300/api/Statistik/CategoryCount");
            var jsonData7 = await responseMessage7.Content.ReadAsStringAsync();
            ViewBag.categoryCount = jsonData7;
            #endregion
            #region İstatistik8
            var client8 = _httpClientFactory.CreateClient();
            var responseMessage8 = await client8.GetAsync("https://localhost:44300/api/Statistik/CategoryNameByMaxProduction");
            var jsonData8 = await responseMessage8.Content.ReadAsStringAsync();
            ViewBag.categoryNameMaxProductCount = jsonData8;
            #endregion
            #region İstatistik9
            var client9 = _httpClientFactory.CreateClient();
            var responseMessage9 = await client9.GetAsync("https://localhost:44300/api/Statistik/CityNameByMaxProductCount");
            var jsonData9 = await responseMessage9.Content.ReadAsStringAsync();
            ViewBag.cityNameMaxProductCount = jsonData9;
            #endregion
            #region İstatistik10
            var client10 = _httpClientFactory.CreateClient();
            var responseMessage10 = await client10.GetAsync("https://localhost:44300/api/Statistik/DifferentCityCount");
            var jsonData10 = await responseMessage10.Content.ReadAsStringAsync();
            ViewBag.differentCity = jsonData10;
            #endregion
            #region İstatistik11
            var client11 = _httpClientFactory.CreateClient();
            var responseMessage11 = await client11.GetAsync("https://localhost:44300/api/Statistik/EmployeeNameByMaxProduction");
            var jsonData11 = await responseMessage11.Content.ReadAsStringAsync();
            ViewBag.employeeNameByMaxProduction = jsonData11;
            #endregion
            #region İstatistik12
            var client12 = _httpClientFactory.CreateClient();
            var responseMessage12 = await client12.GetAsync("https://localhost:44300/api/Statistik/LastProductPrice");
            var jsonData12 = await responseMessage12.Content.ReadAsStringAsync();
            ViewBag.lastProduct = jsonData12;
            #endregion
            #region İstatistik13
            var client13 = _httpClientFactory.CreateClient();
            var responseMessage13 = await client13.GetAsync("https://localhost:44300/api/Statistik/NewestBuildingYear");
            var jsonData13 = await responseMessage13.Content.ReadAsStringAsync();
            ViewBag.newestBuild = jsonData13;
            #endregion
            #region İstatistik14
            var client14 = _httpClientFactory.CreateClient();
            var responseMessage14 = await client14.GetAsync("https://localhost:44300/api/Statistik/OldestBuildingYear");
            var jsonData14 = await responseMessage14.Content.ReadAsStringAsync();
            ViewBag.oldestBuild = jsonData14;
            #endregion
            #region İstatistik15
            var client15 = _httpClientFactory.CreateClient();
            var responseMessage15 = await client15.GetAsync("https://localhost:44300/api/Statistik/PassiveCategoryCount");
            var jsonData15 = await responseMessage15.Content.ReadAsStringAsync();
            ViewBag.passiveCategory = jsonData15;
            #endregion
            #region İstatistik16
            var client16 = _httpClientFactory.CreateClient();
            var responseMessage16 = await client16.GetAsync("https://localhost:44300/api/Statistik/ProductCount");
            var jsonData16 = await responseMessage16.Content.ReadAsStringAsync();
            ViewBag.productCount = jsonData16;
            #endregion
            return View();
        }
    }
}
