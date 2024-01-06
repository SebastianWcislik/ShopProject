#nullable disable

using System.ComponentModel.DataAnnotations;

namespace ShopProjectExternalModel.User
{
    public class UserLoginModel
    {
        [Required(ErrorMessage = "Nazwa użytkownika jest wymagana")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Hasło jest wymagane")]
        public string Password { get; set; }
    }
}
