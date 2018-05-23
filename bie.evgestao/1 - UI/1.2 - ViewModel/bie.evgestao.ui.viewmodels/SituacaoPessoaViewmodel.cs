using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace bie.evgestao.ui.viewmodels
{
    class SituacaoPessoaViewmodel
    {
        [Key]
        public int id_situacaopessoa { get; set; }

        [Required]
        [MaxLength(100, ErrorMessage = "O campo {0} deve ter no máximo {1} caracteres")]
        public string Nome { get; set; }
        public string Tipo { get; set; }
    }
}
