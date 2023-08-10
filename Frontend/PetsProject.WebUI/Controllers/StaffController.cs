using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PetsProject.WebUI.Models.Staff;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace PetsProject.WebUI.Controllers
{
    
    public class StaffController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public StaffController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient(); //istemci oluşturma
            var responseMessage = await client.GetAsync("https://localhost:44310/api/Staff"); //adrese istekte bulunma (swaggerdaki get staff adresi)
            if (responseMessage.IsSuccessStatusCode) //durum kodu dönüş
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<StaffViewModel>>(jsonData); //json formatındaki veriyi tabloda görünecek hale çevirme
                return View(values);
            }
            return View();
        }


        [HttpGet]
        public IActionResult AddStaff()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddStaff(AddStaffViewModel model)
        {

            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(model);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:44310/api/Staff", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();

        }

        public async Task<IActionResult> DeleteStaff(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"https://localhost:44310/api/Staff/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> UpdateStaff(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:44310/api/Staff/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateStaffViewModel>(jsonData);
                return View(values);
            }
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> UpdateStaff(UpdateStaffViewModel model)
        {
            var client = _httpClientFactory.CreateClient();
            var jasonData = JsonConvert.SerializeObject(model);
            StringContent stringContent = new StringContent(jasonData, Encoding.UTF8, "application/json");


            var responseMessage = await client.PutAsync($"https://localhost:44310/api/Staff", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
