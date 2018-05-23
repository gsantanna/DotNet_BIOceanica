using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace bie.evgestao.ui.viewmodels
{
    class FamiliarViewmodel
    {
        [Key]
        public int id_familiar { get; set; }

        [Required(ErrorMessage = "Informa Nome Completo do Familiar")]
        [MaxLength(150, ErrorMessage = "O campo {0} deve ter no máximo {1} caracteres")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Informa Tipo do Familiar")]
        public string Tipo { get; set; }


    }
}
