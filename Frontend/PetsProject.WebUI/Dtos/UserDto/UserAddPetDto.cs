using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.ComponentModel.DataAnnotations;

namespace PetsProject.WebUI.Dtos.UserDto
{
    public class UserAddPetDto
    {

        public SelectList PetTypes { get; set; }
        public SelectList Breeds { get; set; }

        public int PetTypeID { get; set; }
        public int BreedID { get; set; }
        public string PhotoUrl { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
