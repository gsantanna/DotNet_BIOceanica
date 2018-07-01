using bie.evgestao.domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;



namespace bie.evgestao.ui.viewmodels
{
    public class FamiliarViewmodel
    {

        public int id_familiar { get; set; }
        public int id_pessoa { get; set; }

        [Required(ErrorMessage = "Informa Nome Completo do Familiar")]
        [MaxLength(150, ErrorMessage = "O campo {0} deve ter no máximo {1} caracteres")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Informe o grau de parentesco")]
        public GrauParentesco Parentesco { get; set; }




    }
}
