using System.ComponentModel.DataAnnotations;

namespace PetsProject.WebUI.Dtos.LoginDto
{
    public class LoginUserDto
    {
        [Required(ErrorMessage = "kullanıcı adını giriniz")]
        public string Username { get; set; }
        [Required(ErrorMessage = "şifreyi giriniz")]
        public string Password { get; set; }
    }
}
