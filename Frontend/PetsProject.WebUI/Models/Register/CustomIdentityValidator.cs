using Microsoft.AspNetCore.Identity;

namespace PetsProject.WebUI.Models.Register
{
    public class CustomIdentityValidator :IdentityErrorDescriber
    {
        public override IdentityError PasswordTooShort(int length)
        {
            return new IdentityError()
            {
                Code = "PasswordTooShort",
                Description = $"Şifreniz en az {length} karakter olmalıdır!"
            };
        }

        public override IdentityError PasswordRequiresUpper()
        {
            return new IdentityError()
            {
                Code = "PasswordRequiresUpper",
                Description ="Şifreniz en az 1 büyük harf içermelidir!"
            };
        }

        public override IdentityError PasswordRequiresLower()
        {
            return new IdentityError()
            {
                Code = "PasswordRequiresLower",
                Description = "Şifreniz en az 1 küçük harf içermelidir!"
            };
        }

        

        public override IdentityError PasswordRequiresNonAlphanumeric()
        {
            return new IdentityError()
            {
                Code = "PasswordRequiresUniqueChars",
                Description = "Şifrenizde en az 1 sembol olmalıdır!"
            };
        }
    }
}
