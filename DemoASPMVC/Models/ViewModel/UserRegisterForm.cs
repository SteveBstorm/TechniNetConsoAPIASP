using System.ComponentModel.DataAnnotations;

namespace DemoASPMVC.Models.ViewModel
{
    public class UserRegisterForm
    {
        [Required]
        [MinLength(3, ErrorMessage = "Taille minimale : 3 Caratères")]
        public string Nickname { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        [DataType(DataType.Password)]
        [RegularExpression("^(?=.*[A-Za-z])(?=.*\\d)(?=.*[@$!%*#?&])[A-Za-z\\d@$!%*#?&]{8,}$")]
        public string Password { get; set; }
        [DataType(DataType.Password)]
        [Compare(nameof(Password), ErrorMessage = "Les 2 mots de passe doivent correspondre")]
        public string ConfirmPassword { get; set; }
    }
}
