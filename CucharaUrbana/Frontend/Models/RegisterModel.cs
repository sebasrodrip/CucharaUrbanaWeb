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
        [Display(Name = "Confirmar Contraseña")]
        [Compare("Contraseña",
            ErrorMessage = "Contraseñas no coinciden.")]
        public string ConfirmPassword { get; set; }
    }
}
