using Microsoft.AspNetCore.Mvc;

namespace PetsProject.WebUI.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
