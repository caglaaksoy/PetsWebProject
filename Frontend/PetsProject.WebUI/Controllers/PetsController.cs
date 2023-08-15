using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PetsProject.DataAccessLayer.Concrete;
using PetsProject.EntityLayer.Concrete;
using PetsProject.WebUI.Dtos.OwnerDto;
using PetsProject.WebUI.Dtos.PetsDto;
using PetsProject.WebUI.Models.Owner;
using PetsProject.WebUI.Models.pets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace PetsProject.WebUI.Controllers
{
    public class PetsController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private string jsonData;
        private string target;

        public PetsController(IHttpClientFactory httpClientFactory, IConfiguration configuration)
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
            var responseMessage = await client.GetAsync($"{target}/api/Pets");

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultOwnerDto>>(jsonData);
                var pets = JsonConvert.DeserializeObject<List<Pets>>(jsonData);

                List<SelectListItem> ownerValues = values.Select(x => new SelectListItem
                {
                    Text = x.Name + " " + x.Surname,
                    Value = x.OwnerID.ToString()
                }).ToList();
                ViewBag.v = ownerValues;

                List<PetsViewModel> petsViewModels = pets.Select(pet => new PetsViewModel
                {
                    PetsID = pet.PetsID,
                    Name = pet.Name,
                    PhotoUrl = pet.PhotoUrl,
                    Age = pet.Age,
                    Gender = pet.Gender,
                    Type = pet.Type,
                    BirthDate = pet.BirthDate,
                    RegisterDate = pet.RegisterDate,
                    OwnerID = pet.OwnerID
                }).ToList();

                // Pass petsViewModels as the model to the view
                return View(petsViewModels);

            }

            return View();

        }

        [HttpGet]
        public IActionResult AddPet()
        {
            using (var dbContext = new Context()) // Replace with your DbContext class name
            {
                List<SelectListItem> ownerValues = dbContext.Owners
                    .Select(owner => new SelectListItem
                    {
                        Text = owner.Name + " " + owner.Surname,
                        Value = owner.OwnerID.ToString(),
                    })
                    .ToList();

                ViewBag.v = ownerValues;
            }

            return View();
        }


        [HttpPost]
        public async Task<IActionResult> AddPet(CreatePetDto createPetDto)
        {
            //  addPetsViewModel.RegisterDate = DateTime.Parse(DateTime.Now.ToShortDateString());

            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createPetDto);

            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            await client.PostAsync($"{target}/api/Pets", stringContent);

            using (var dbContext = new Context()) // Replace with your DbContext class name
            {
                List<SelectListItem> ownerValues = dbContext.Owners
                    .Select(owner => new SelectListItem
                    {
                        Text = owner.Name + " " + owner.Surname,
                        Value = owner.OwnerID.ToString(),
                    })
                    .ToList();

                ViewBag.v = ownerValues;

            }

            // Pass addPetsViewModel as the model to the view
            return View(createPetDto);
        }



        public async Task<IActionResult> DeletePet(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"{target}/api/Pets/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> UpdatePet(int id)
        {
            //var client = _httpClientFactory.CreateClient();
            //var responseMessage = await client.GetAsync($"{target}/api/Pets/{id}");

            //if (responseMessage.IsSuccessStatusCode)
            //{
            //    var jsonData = await responseMessage.Content.ReadAsStringAsync();
            //    var values = JsonConvert.DeserializeObject<UpdatePetDto>(jsonData);
            //    return View(values);
            //}
            using (var dbContext = new Context()) // Replace with your DbContext class name
            {
                List<SelectListItem> ownerValues = dbContext.Owners
                    .Select(owner => new SelectListItem
                    {
                        Text = owner.Name + " " + owner.Surname,
                        Value = owner.OwnerID.ToString(),
                    })
                    .ToList();

                ViewBag.v = ownerValues;

            }
            return View();
        }



        [HttpPost]
        public async Task<IActionResult> UpdatePet(UpdatePetDto dto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(dto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync($"{target}/api/Pets", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                using (var dbContext = new Context())
                {
                    List<SelectListItem> ownerValues = dbContext.Owners
                        .Select(owner => new SelectListItem
                        {
                            Text = owner.Name + " " + owner.Surname,
                            Value = owner.OwnerID.ToString(),
                        })
                        .ToList();

                    ViewBag.v = ownerValues;

                }
                return RedirectToAction("Index");
            }
            return View();
            
            
        }


    }
}
