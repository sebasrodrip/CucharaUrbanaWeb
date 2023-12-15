using System.ComponentModel.DataAnnotations;

namespace Frontend.Models
{
    public class RegisterModel
    {


        [Required]
        [Display(Name = "Usuario")]
        public string UserName { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Contraseña")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Passwords do not match")]
        [Required(ErrorMessage = "Password confirmation is required")]
        public string ConfirmPassword { get; set; }
    }
}
