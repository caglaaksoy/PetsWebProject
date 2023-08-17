using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using PetsProject.WebUI.Dtos.FeatureDto;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System;
using PetsProject.WebUI.Dtos.ShopProcessDto;

namespace PetsProject.WebUI.Controllers
{
    public class ShopProcessController : Controller
    {

        private readonly IHttpClientFactory _httpClientFactory;
        private string target;

        public ShopProcessController(IHttpClientFactory httpClientFactory, IConfiguration configuration)
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
            var responseMessage = await client.GetAsync($"{target}/api/ShopProcess");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultShopProcessDto>>(jsonData);
                return View(values);
            }
            return View();
        }

        //[HttpGet]
        //public IActionResult AddShopProcess()
        //{
        //    return View();
        //}
        //[HttpPost]
        //public async Task<IActionResult> AddShopProcess(CreateShopProcessDto createShopProcessDto)
        //{

        //    if (!ModelState.IsValid)
        //    {
        //        return View();
        //    }

        //    var client = _httpClientFactory.CreateClient();
        //    var jsonData = JsonConvert.SerializeObject(createShopProcessDto);
        //    StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
        //    var responseMessage = await client.PostAsync($"{target}/api/ShopProcess", stringContent);
        //    if (responseMessage.IsSuccessStatusCode)
        //    {
        //        return RedirectToAction("Index");
        //    }
        //    return View();

        //}

        //public async Task<IActionResult> DeleteShopProcess(int id)
        //{
        //    var client = _httpClientFactory.CreateClient();
        //    var responseMessage = await client.DeleteAsync($"{target}/api/ShopProcess/{id}");
        //    if (responseMessage.IsSuccessStatusCode)
        //    {
        //        return RedirectToAction("Index");
        //    }
        //    return View();
        //}

        //[HttpGet]
        //public async Task<IActionResult> UpdateShopProcess(int id)
        //{
        //    var client = _httpClientFactory.CreateClient();
        //    var responseMessage = await client.GetAsync($"{target}/api/ShopProcess/{id}");
        //    if (responseMessage.IsSuccessStatusCode)
        //    {
        //        var jsonData = await responseMessage.Content.ReadAsStringAsync();
        //        var values = JsonConvert.DeserializeObject<UpdateShopProcessDto>(jsonData);
        //        return View(values);
        //    }
        //    return View();
        //}


        //[HttpPost]
        //public async Task<IActionResult> UpdateShopProcess(UpdateShopProcessDto updateShopProcessDto)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return View();
        //    }
        //    var client = _httpClientFactory.CreateClient();
        //    var jasonData = JsonConvert.SerializeObject(updateShopProcessDto);
        //    StringContent stringContent = new StringContent(jasonData, Encoding.UTF8, "application/json");


        //    var responseMessage = await client.PutAsync($"{target}/api/ShopProcess/", stringContent);
        //    if (responseMessage.IsSuccessStatusCode)
        //    {
        //        return RedirectToAction("Index");
        //    }
        //    return View();
        //}


    }
}
