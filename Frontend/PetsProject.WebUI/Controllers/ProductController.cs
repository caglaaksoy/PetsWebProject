using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using PetsProject.WebUI.Dtos.FeatureDto;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System;
using Microsoft.AspNetCore.JsonPatch.Internal;
using PetsProject.WebUI.Dtos.ProductDto;

namespace PetsProject.WebUI.Controllers
{
    public class ProductController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private string target;

        public ProductController(IHttpClientFactory httpClientFactory, IConfiguration configuration)
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
            var responseMessage = await client.GetAsync($"{target}/api/Product");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultProductDto>>(jsonData);
                return View(values);
            }
            return View();
        }

        //[HttpGet]
        //public IActionResult AddProduct()
        //{
        //    return View();
        //}
        //[HttpPost]
        //public async Task<IActionResult> AddProduct(CreateProductDto createProductDto)
        //{

        //    if (!ModelState.IsValid)
        //    {
        //        return View();
        //    }

        //    var client = _httpClientFactory.CreateClient();
        //    var jsonData = JsonConvert.SerializeObject(createProductDto);
        //    StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
        //    var responseMessage = await client.PostAsync($"{target}/api/Product", stringContent);
        //    if (responseMessage.IsSuccessStatusCode)
        //    {
        //        return RedirectToAction("Index");
        //    }
        //    return View();

        //}

        //public async Task<IActionResult> DeleteProduct(int id)
        //{
        //    var client = _httpClientFactory.CreateClient();
        //    var responseMessage = await client.DeleteAsync($"{target}/api/Product/{id}");
        //    if (responseMessage.IsSuccessStatusCode)
        //    {
        //        return RedirectToAction("Index");
        //    }
        //    return View();
        //}

        //[HttpGet]
        //public async Task<IActionResult> UpdateProduct(int id)
        //{
        //    var client = _httpClientFactory.CreateClient();
        //    var responseMessage = await client.GetAsync($"{target}/api/Product/{id}");
        //    if (responseMessage.IsSuccessStatusCode)
        //    {
        //        var jsonData = await responseMessage.Content.ReadAsStringAsync();
        //        var values = JsonConvert.DeserializeObject<UpdateProductDto>(jsonData);
        //        return View(values);
        //    }
        //    return View();
        //}


        //[HttpPost]
        //public async Task<IActionResult> UpdateProduct(UpdateProductDto updateProductDto)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return View();
        //    }
        //    var client = _httpClientFactory.CreateClient();
        //    var jasonData = JsonConvert.SerializeObject(updateProductDto);
        //    StringContent stringContent = new StringContent(jasonData, Encoding.UTF8, "application/json");


        //    var responseMessage = await client.PutAsync($"{target}/api/Product/", stringContent);
        //    if (responseMessage.IsSuccessStatusCode)
        //    {
        //        return RedirectToAction("Index");
        //    }
        //    return View();
        //}
    }
}
