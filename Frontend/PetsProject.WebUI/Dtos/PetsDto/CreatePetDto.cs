using System;

namespace PetsProject.WebUI.Dtos.PetsDto
{
    public class CreatePetDto
    {
        public string Name { get; set; }
        public string PhotoUrl { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public string Type { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime RegisterDate { get; set; }
        public int OwnerID { get; set; }
    }
}
