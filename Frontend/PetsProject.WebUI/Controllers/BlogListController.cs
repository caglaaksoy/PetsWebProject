using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using PetsProject.WebUI.Dtos.BlogDto;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PetsProject.DataAccessLayer.Concrete;

namespace PetsProject.WebUI.Controllers
{
    public class BlogListController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private string target;
        private readonly Context _dbContext;

        public BlogListController(IHttpClientFactory httpClientFactory, IConfiguration configuration, Context dbContext)
        {
            _dbContext = dbContext;
            _httpClientFactory = httpClientFactory;
            target = configuration["BackendTarget"];
            if (string.IsNullOrEmpty(target))
            {
                throw new Exception("lütfen target değerini girin.");
            }
        }

        public async Task<IActionResult> Index(int? page)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"{target}/api/Blog");

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var allBlogs = JsonConvert.DeserializeObject<List<ResultBlogDto>>(jsonData);

                int blogsPerPage = 3;
                int totalBlogs = allBlogs.Count;
                int totalPages = (int)Math.Ceiling((double)totalBlogs / blogsPerPage);

                int currentPage = page ?? 1;
                var startIndex = (currentPage - 1) * blogsPerPage;

                // Önce tüm blogları getirip ardından sadece son 3 blogu filtrele
                var pagedBlogs = allBlogs.Skip(startIndex).Take(blogsPerPage).ToList();

                ViewBag.TotalPages = totalPages;
                ViewBag.CurrentPage = currentPage;

                // Tüm blogları kullanarak son 3 blogu getir
                var lastThreeBlogs = allBlogs.OrderByDescending(b => b.Date).Take(3).ToList();

                ViewBag.LastThreeBlogs = lastThreeBlogs;

                return View(pagedBlogs);
            }

            return View();
        }

        public async Task<IActionResult> ReadAllBlog(int id)
        {
            
            // Burada id parametresini kullanarak ilgili blogun verilerini çekin.
            // Örnek olarak, _dbContext veya başka bir veritabanı bağlantısı kullanabilirsiniz.
            var blog = _dbContext.Blogs.FirstOrDefault(b => b.BlogID == id);

            // Blog verisi varsa, bu veriyi modele atayın ve view'e gönderin.
            if (blog != null)
            {
                var model = new List<ResultBlogDto>
        {
            // Burada blog verisini ResultBlogDto'ya dönüştürerek modele ekleyin.
            new ResultBlogDto
            {
                BlogID = blog.BlogID,
                BlogTitle = blog.BlogTitle,
                Writer = blog.Writer,
                BlogPhotoUrl = blog.BlogPhotoUrl,
                Text = blog.Text,
                Date = blog.Date
            }
        };
                return View(model);
            }

            // Eğer blog verisi bulunamazsa, bir hata mesajı veya yönlendirme sayfası gösterebilirsiniz.
            return NotFound(); // Örnek olarak 404 sayfası gösterme.

        }













    }
}
