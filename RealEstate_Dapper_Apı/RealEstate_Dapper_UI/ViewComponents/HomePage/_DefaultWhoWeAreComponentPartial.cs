﻿using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RealEstate_Dapper_UI.Dtos.ProductDtos;
using RealEstate_Dapper_UI.Dtos.ServiceDtos;
using RealEstate_Dapper_UI.Dtos.WhoWeAreDtos;

namespace RealEstate_Dapper_UI.ViewComponents.HomePage
{
    public class _DefaultWhoWeAreComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _DefaultWhoWeAreComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var client2 = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:44300/api/WhoWeAre");
            var responseMessage2 = await client2.GetAsync("https://localhost:44300/api/Service");
            if (responseMessage.IsSuccessStatusCode && responseMessage2.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var jsonData2 = await responseMessage2.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultWhoWeAreDtos>>(jsonData);
                var values2 = JsonConvert.DeserializeObject<List<ResultServiceDto>>(jsonData);

                ViewBag.a = values.Select(x => x.Title).FirstOrDefault();
                ViewBag.b = values.Select(x => x.SubTitle).FirstOrDefault();
                ViewBag.c = values.Select(x => x.Description1).FirstOrDefault();
                ViewBag.d = values.Select(x => x.Description2).FirstOrDefault();
                return View(values2);

            }
            return View();
        }
    }
}
