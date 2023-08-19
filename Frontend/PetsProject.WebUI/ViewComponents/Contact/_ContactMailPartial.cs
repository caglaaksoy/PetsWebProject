using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using PetsProject.WebUI.Dtos.TeamDto;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System;
using PetsProject.WebUI.Dtos.ContactDto;
using System.Text;

namespace PetsProject.WebUI.ViewComponents.Contact
{
    public class _ContactMailPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private string target;

        public _ContactMailPartial(IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            _httpClientFactory = httpClientFactory;
            target = configuration["BackendTarget"];
            if (string.IsNullOrEmpty(target))
            {
                throw new Exception("lütfen target değerini girin.");
            }
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"{target}/api/Contact");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<InboxContactDto>>(jsonData);
                return View(values);
            }
            return View();
        }

    }
}
