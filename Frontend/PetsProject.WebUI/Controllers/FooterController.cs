using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using PetsProject.WebUI.Dtos.FeatureDto;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System;
using PetsProject.WebUI.Dtos.FooterDto;

namespace PetsProject.WebUI.Controllers
{
    public class FooterController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private string target;

        public FooterController(IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            _httpClientFactory = httpClientFactory;
            target = configuration["BackendTarget"];
            if (string.IsNullOrEmpty(target))
            {
                throw new Exception("lütfen target değerini girin.");
            }
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"{target}/api/Footer");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultFooterDto>>(jsonData);
                return View(values);
            }
            return View();
        }


        [HttpGet]
        public async Task<IActionResult> UpdateFooter(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"{target}/api/Footer/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateFooterDto>(jsonData);
                return View(values);
            }
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> UpdateFeature(UpdateFooterDto updateFooterDto)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var client = _httpClientFactory.CreateClient();
            var jasonData = JsonConvert.SerializeObject(updateFooterDto);
            StringContent stringContent = new StringContent(jasonData, Encoding.UTF8, "application/json");


            var responseMessage = await client.PutAsync($"{target}/api/Footer/", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
