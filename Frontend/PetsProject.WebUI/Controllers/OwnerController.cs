using Microsoft.AspNetCore.Mvc;

namespace PetsProject.WebUI.Controllers
{
    public class OwnerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
