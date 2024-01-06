#nullable disable

using System.ComponentModel.DataAnnotations;

namespace ShopProjectExternalModel.User
{
    public class UserRegisterModel
    {
        [Required(ErrorMessage = "Nazwa użytkownika jest wymagana")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Email jest wymagany")]
        [EmailAddress(ErrorMessage = "Email jest niepoprawny")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Hasło jest wymagane")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Hasło jest wymagane")]
        [Compare("Password", ErrorMessage = "Hasła się nie zgadzają")]
        public string PasswordConfirm { get; set; }
    }
}
