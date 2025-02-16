using Microsoft.AspNetCore.SignalR;

namespace RealEstate_Dapper_API.Hubs
{
    public class SignalRHub:Hub
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public SignalRHub(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task SendCategoryCount()
        {
            var client7 = _httpClientFactory.CreateClient();
            var responseMessage7 = await client7.GetAsync("https://localhost:44300/api/Statistik/CategoryCount");
            var jsonData7 = await responseMessage7.Content.ReadAsStringAsync();
            await Clients.All.SendAsync("ReceiveCategoryCount",jsonData7);
        
        }
    }
}
