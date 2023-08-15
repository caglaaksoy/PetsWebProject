using Microsoft.AspNetCore.Mvc;

namespace PetsProject.WebUI.Controllers
{
    public class DefaultController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
