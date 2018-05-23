
using System.ComponentModel.DataAnnotations;

namespace bie.evgestao.ui.viewmodels
{
    class GrauParentescoViewmodel
    {
        [Key]
        public int id_grauparentesco { get; set; }

        [Required(ErrorMessage ="Informe o grau de parentesco")]
        [Display(Name ="Grau de Parentesco")]
        public string Nome { get; set; }
    }
}
