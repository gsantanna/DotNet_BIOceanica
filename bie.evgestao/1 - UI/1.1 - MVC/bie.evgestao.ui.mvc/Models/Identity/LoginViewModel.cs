using System.ComponentModel.DataAnnotations;

namespace bie.evgestao.ui.mvc.Models
{
    public class LoginViewModel
    {
        [Required]
        [Display(Name = "E-mail")]
        [EmailAddress(ErrorMessage ="Email inválido")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Senha")]
        public string Password { get; set; }

        [Display(Name = "Guardar dados?")]
        public bool RememberMe { get; set; }
    }
}