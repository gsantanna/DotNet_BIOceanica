using System.ComponentModel.DataAnnotations;

namespace bie.evgestao.ui.mvc.Models
{
    public class ForgotViewModel
    {
        [Required]
        [Display(Name = "E-mail")]
        public string Email { get; set; }
    }
}