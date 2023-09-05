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
        private readonly SignInManager<AppUser> _signInManager;

        public ProfileController(UserManager<AppUser> userManager, Context dbContext, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _dbContext = dbContext;
            _signInManager = signInManager;
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
            var petTypes = _dbContext.PetTypes.ToList();
            var breeds = _dbContext.Breeds.ToList();

            var petDto = new UserAddPetDto
            {
                PetTypes = new SelectList(petTypes, "PetTypeID", "PetTypeName"),
                Breeds = new SelectList(breeds, "BreedID", "BreedName")
            };

            return View(petDto);
        }



        [HttpGet]
        public IActionResult GetBreedsByPetType(int PetTypeID)
        {
            var breeds = _dbContext.Breeds.Where(b => b.PetTypeID == PetTypeID).Select(b => b.BreedName).ToList();
            return Json(breeds);
        }

        [HttpPost]
        public IActionResult UserAddPet(UserAddPetDto petDto)
        {
            if (ModelState.IsValid)
            {
                var user = _userManager.GetUserAsync(User).Result;

                if (user != null)
                {
                    // Pet fotoğrafını kaydet
                    var petPhotoFile = petDto.PhotoUrl;

                    // Pet fotoğrafını veritabanına kaydet
                    var newPet = new Pets
                    {
                        Name = petDto.Name,
                        Gender = petDto.Gender,
                        BirthDate = petDto.BirthDate,
                        BreedID = petDto.BreedID,
                        AppUserId = user.Id,
                        PhotoUrl = petDto.PhotoUrl
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



        [HttpGet]
        public IActionResult UserPetList()
        {
            var user = _userManager.GetUserAsync(User).Result;

            if (user != null)
            {
                var userPets = _dbContext.Petss.Where(p => p.AppUserId == user.Id).ToList();

                // UserAddPetDto türünden bir IEnumerable oluştur
                var userPetDtos = userPets.Select(p => new UserAddPetDto
                {
                    Name = p.Name,
                    Gender = p.Gender,
                    BirthDate = p.BirthDate,
                    BreedID = p.BreedID,
                    PhotoUrl = $"~/uploads/{p.PhotoUrl}"
                });

                return View(userPetDtos);
            }

            return View();
        }



        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync(); // SignInManager'ı kullanarak çıkış yap
            return RedirectToAction("Index", "Default");
        }

    }


}