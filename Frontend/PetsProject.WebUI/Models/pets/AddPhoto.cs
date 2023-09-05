using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using PetsProject.EntityLayer.Concrete;
using System;

namespace PetsProject.WebUI.Models.pets
{
    public class AddPhoto
    {
        public SelectList PetTypes { get; set; }
        public SelectList Breeds { get; set; }

        public int PetTypeID { get; set; }
        public int BreedID { get; set; }
        public IFormFile PhotoUrl { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public DateTime BirthDate { get; set; }



    }
}
