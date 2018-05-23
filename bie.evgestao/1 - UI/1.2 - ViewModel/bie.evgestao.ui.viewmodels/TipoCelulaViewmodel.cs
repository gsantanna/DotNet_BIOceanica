using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bie.evgestao.ui.viewmodels
{
    class TipoCelulaViewmodel
    {
        [Key]
        public int id_tipocelula { get; set; }

        [Required(ErrorMessage = "Informe o Tipo da Célula")]
        [Display(Name = "Tipo da Célula")]
        [MaxLength(100, ErrorMessage = "O campo {0} deve ter no máximo {1} caracteres")]
        public string Tipo { get; set; }
    }
}
