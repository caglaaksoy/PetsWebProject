using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PetsProject.EntityLayer.Concrete;
using PetsProject.WebUI.Dtos.UserDto;
using System;
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
        public async Task<IActionResult> Index()
        {
            try
            {
                if (User.Identity.IsAuthenticated)
                {
                    var user = await _userManager.GetUserAsync(User);

                    if (user != null)
                    {
                        UserProfileDto userProfileDto = new UserProfileDto
                        {                            
                            Username = user.UserName
                        };

                        return View(userProfileDto);
                    }
                }
            }
            catch (Exception ex)
            {
                // Hata mesajını konsola yazdır
                Console.WriteLine(ex.Message);
            }
            return View();

            return View();
        }
    }
}
