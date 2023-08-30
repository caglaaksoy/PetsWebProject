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
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.Linq;

namespace PetsProject.WebUI.Controllers
{
    public class ProfileController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly Context _dbContext;

        public ProfileController(UserManager<AppUser> userManager, Context dbContext)
        {
            _userManager = userManager;
            _dbContext = dbContext;
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





        public IActionResult UserAddPet()
        {
            ViewBag.PetTypes = _dbContext.PetTypes.ToList();
            ViewBag.Breeds = _dbContext.Breeds.ToList();

            return View(new UserAddPetDto());
        }

        [HttpPost]
        public IActionResult UserAddPet(UserAddPetDto petDto)
        {
            if (ModelState.IsValid)
            {
                var user = _userManager.GetUserAsync(User).Result;

                if (user != null)
                {
                    var newPet = new Pets
                    {
                        Name = petDto.Name,
                        Gender = petDto.Gender,
                        BirthDate = petDto.BirthDate,
                        ///BreedID = petDto.BreedId,
                        AppUserId = user.Id
                    };

                    _dbContext.Petss.Add(newPet);
                    _dbContext.SaveChanges();

                    TempData["SuccessMessage"] = "Yeni pet eklendi!";
                    return RedirectToAction("Index", "Profile");
                }
            }

            ViewBag.PetTypes = _dbContext.PetTypes.ToList();
            ViewBag.Breeds = _dbContext.Breeds.ToList();
            return View(petDto);
        }



    }
}

