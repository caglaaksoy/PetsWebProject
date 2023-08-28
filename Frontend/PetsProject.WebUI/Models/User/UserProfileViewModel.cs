using PetsProject.EntityLayer.Concrete;
using System.Collections.Generic;

namespace PetsProject.WebUI.Models.User
{
    public class UserProfileViewModel
    {
        public string Name { get; set; } 
        public string Surname { get; set; }
        public string Email { get; set; }
        public List<AppUser> AppUsers { get; set; }
    }
}
