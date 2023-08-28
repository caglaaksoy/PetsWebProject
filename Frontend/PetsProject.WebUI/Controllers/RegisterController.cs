using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using PetsProject.EntityLayer.Concrete;
using PetsProject.WebUI.Dtos.RegisterDto;
using System.Net.Http;
using System;
using System.Threading.Tasks;
using PetsProject.WebUI.Models.Register;

namespace PetsProject.WebUI.Controllers
{
    public class RegisterController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public RegisterController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(CreateNewUserDto createNewUserDto)
        {

            AppUser appUser = new AppUser()
            {
                Name = createNewUserDto.Name,
                Email = createNewUserDto.Mail,
                Surname = createNewUserDto.Surname,
                UserName = createNewUserDto.Username
            };
            if (createNewUserDto.Password == createNewUserDto.ConfirmPassword)
            {
                var result = await _userManager.CreateAsync(appUser, createNewUserDto.Password);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "MemberHome");
                }
                //else
                //{
                //    foreach (var item in result.Errors)
                //    {
                //        ModelState.AddModelError("", item.Description);
                //    }
                //}
            }
            return View(createNewUserDto);
        }
    }
}

