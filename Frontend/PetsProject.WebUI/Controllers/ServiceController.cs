﻿using Microsoft.AspNetCore.Mvc;
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

           
        }
}
