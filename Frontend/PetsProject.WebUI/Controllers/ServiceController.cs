using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using PetsProject.WebUI.Dtos.FeatureDto;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System;
using PetsProject.WebUI.Dtos.ServiceDto;

namespace PetsProject.WebUI.Controllers
{
    public class ServiceController : Controller
    {
        
            private readonly IHttpClientFactory _httpClientFactory;
            private string target;

            public ServiceController(IHttpClientFactory httpClientFactory, IConfiguration configuration)
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
                var responseMessage = await client.GetAsync($"{target}/api/Service");
                if (responseMessage.IsSuccessStatusCode)
                {
                    var jsonData = await responseMessage.Content.ReadAsStringAsync();
                    var values = JsonConvert.DeserializeObject<List<ResultServiceDto>>(jsonData);
                    return View(values);
                }
                return View();
            }

            [HttpGet]
            public IActionResult AddService()
            {
                return View();
            }
            [HttpPost]
            public async Task<IActionResult> AddService(CreateServiceDto createServiceDto)
            {

                if (!ModelState.IsValid)
                {
                    return View();
                }

                var client = _httpClientFactory.CreateClient();
                var jsonData = JsonConvert.SerializeObject(createServiceDto);
                StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
                var responseMessage = await client.PostAsync($"{target}/api/Service", stringContent);
                if (responseMessage.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
                return View();

            }

            public async Task<IActionResult> DeleteService(int id)
            {
                var client = _httpClientFactory.CreateClient();
                var responseMessage = await client.DeleteAsync($"{target}/api/Service/{id}");
                if (responseMessage.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
                return View();
            }

            [HttpGet]
            public async Task<IActionResult> UpdateService(int id)
            {
                var client = _httpClientFactory.CreateClient();
                var responseMessage = await client.GetAsync($"{target}/api/Service/{id}");
                if (responseMessage.IsSuccessStatusCode)
                {
                    var jsonData = await responseMessage.Content.ReadAsStringAsync();
                    var values = JsonConvert.DeserializeObject<UpdateServiceDto>(jsonData);
                    return View(values);
                }
                return View();
            }


            [HttpPost]
            public async Task<IActionResult> UpdateService(UpdateServiceDto updateServiceDto)
            {
                if (!ModelState.IsValid)
                {
                    return View();
                }
                var client = _httpClientFactory.CreateClient();
                var jasonData = JsonConvert.SerializeObject(updateServiceDto);
                StringContent stringContent = new StringContent(jasonData, Encoding.UTF8, "application/json");


                var responseMessage = await client.PutAsync($"{target}/api/Service/", stringContent);
                if (responseMessage.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
                return View();
            }
        }
}
