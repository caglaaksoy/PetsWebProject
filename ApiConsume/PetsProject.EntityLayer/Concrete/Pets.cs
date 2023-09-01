using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PetsProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetsProject.EntityLayer.Concrete
{
    public class Pets
    {
        public int PetsID { get; set; }
        public string Name { get; set; }
        public string PhotoUrl { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime RegisterDate { get; set; }



        public int BreedID { get; set; }
        public Breed Breed { get; set; }



        public int AppUserId { get; set; } 
        public AppUser AppUser { get; set; }
    }
}
//[HttpPost]
//public async Task<IActionResult> UserAddPet(UserAddPetDto petDto, IFormFile photo)
//{
//    if (ModelState.IsValid)
//    {
//        var user = await _userManager.GetUserAsync(User);

//        if (user != null)
//        {
//            if (photo != null && photo.Length > 0)
//            {
//                // Kullanıcının yüklediği fotoğrafı wwwroot/uploads klasörüne kaydetme işlemi
//                var uniqueFileName = Guid.NewGuid().ToString() + "_" + Path.GetFileName(photo.FileName);
//                var uploadPath = Path.Combine(_env.WebRootPath, "uploads"); // _env değişkeni IWebHostEnvironment nesnesini temsil eder
//                var filePath = Path.Combine(uploadPath, uniqueFileName);

//                using (var stream = new FileStream(filePath, FileMode.Create))
//                {
//                    await photo.CopyToAsync(stream);
//                }

//                // Pet bilgilerini veritabanına kaydetme işlemi
//                var newPet = new Pets
//                {
//                    Name = petDto.Name,
//                    Gender = petDto.Gender,
//                    BirthDate = petDto.BirthDate,
//                    BreedID = petDto.BreedID,
//                    AppUserId = user.Id,
//                    PhotoUrl = uniqueFileName // Fotoğraf dosya adını kaydedin
//                };

//                _dbContext.Petss.Add(newPet);
//                _dbContext.SaveChanges();

//                TempData["SuccessMessage"] = "Yeni pet eklendi!";
//                return RedirectToAction("Index", "Profile");
//            }
//        }
//    }

//    ViewBag.Breeds = new SelectList(_dbContext.Breeds, "BreedID", "BreedName");
//    return View(petDto);
//}