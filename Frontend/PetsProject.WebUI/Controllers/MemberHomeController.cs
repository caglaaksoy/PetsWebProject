using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PetsProject.EntityLayer.Concrete;
using System.Threading.Tasks;

namespace PetsProject.WebUI.Controllers
{
    public class MemberHomeController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public MemberHomeController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }
        public IActionResult Index()
        {
           
            return View();
        }
    }
}
