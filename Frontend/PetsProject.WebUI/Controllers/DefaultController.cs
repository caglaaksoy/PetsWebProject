using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Net.Http;
using System;
using Newtonsoft.Json;
using PetsProject.WebUI.Dtos.BlogDto;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace PetsProject.WebUI.Controllers
{
    public class DefaultController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private string target;

        public DefaultController(IHttpClientFactory httpClientFactory, IConfiguration configuration)
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
            var responseMessage = await client.GetAsync($"{target}/api/Blog");

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var allBlogs = JsonConvert.DeserializeObject<List<ResultBlogDto>>(jsonData);
                var blogs = allBlogs.Take(6).ToList();
                ViewBag.blogs = blogs;
            }
            return View();
        }
    }
}
