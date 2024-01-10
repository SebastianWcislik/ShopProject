using System.ComponentModel.DataAnnotations;

namespace ShopProjectExternalModel.User
{
    public class UserUpdateModel
    {
        public int UserId { get; set; }
        [Required(ErrorMessage = "Hasło jest wymagane")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Hasło jest wymagane")]
        [Compare("Password", ErrorMessage = "Hasła się nie zgadzają")]
        public string PasswordConfirm { get; set; }
    }
}
