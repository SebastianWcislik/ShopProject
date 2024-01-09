using System.ComponentModel.DataAnnotations;

namespace ShopProjectExternalModel.User
{
    public class UserUpdateModel
    {
        public int UserId { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        [Compare("Password", ErrorMessage = "Hasła się nie zgadzają")]
        public string ConfirmPassword { get; set; }
    }
}
