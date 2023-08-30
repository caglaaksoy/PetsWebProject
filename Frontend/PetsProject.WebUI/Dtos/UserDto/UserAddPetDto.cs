using System;

namespace PetsProject.WebUI.Dtos.UserDto
{
    public class UserAddPetDto
    {
       
     

        public int PetTypeId { get; set; }
        public int BreedId { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
