using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using PetsProject.EntityLayer.Concrete;
using PetsProject.WebUI.Models.User;
using System.Net.Http;
using System;
using System.Threading.Tasks;
using PetsProject.DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Xml.Linq;
using Newtonsoft.Json;
using PetsProject.WebUI.Dtos.FeatureDto;
using System.IO;
using PetsProject.WebUI.Dtos.UserDto;
using Microsoft.AspNetCore.Authorization;

namespace PetsProject.WebUI.Controllers
{
   
    public class ProfileController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public ProfileController(UserManager<AppUser> userManager)
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
                            Name = user.Name,
                            Surname = user.Surname,
                            Email = user.Email,
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

            //return View(new UserProfileDto() { 
            
            //    Name= "Çağla",
            //    Surname ="Aksoy"
                
            //});


            //if (User.Identity.IsAuthenticated)
            //{
            //    var values = await _userManager.FindByNameAsync(User.Identity.Name);
            //    ViewBag.userName = values.Name + " " + values.Surname;
            //    return View();
            //}


            //return View();
        }

















        //public IActionResult UserAddPet()
        //{
        //    return View();
        //}














        //[HttpPost]
        //public IActionResult UserAddPet(Pets pet)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        // Veritabanına pet eklemek için gerekli kodları burada yazın
        //        // Pet verisi AppUser'a bağlı olarak kaydedilmeli

        //        return RedirectToAction("Index"); // Veya istediğiniz bir yere yönlendirin
        //    }
        //    return View(pet); // Eğer model geçerli değilse tekrar formu gösterin
        //}


    }
}

