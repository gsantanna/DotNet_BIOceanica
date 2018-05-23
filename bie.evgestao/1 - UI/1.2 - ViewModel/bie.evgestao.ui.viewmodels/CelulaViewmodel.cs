using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace bie.evgestao.ui.viewmodels
{
    class CelulaViewmodel
    {
        [Key]
        public string id_celula { get; set; }

        [Required(ErrorMessage = "Informe o Coordenador da Célula")]
        [MaxLength(100, ErrorMessage = "O campo {0} deve ter no máximo {1} caracteres")]
        public string Coordenador { get; set; }

        public string Supervidor { get; set; }

        [Required(ErrorMessage = "Informe o Endereço da Célula")]
        [MaxLength(250, ErrorMessage = "O campo {0} deve ter no máximo {1} caracteres")]
        public string Endereco { get; set; }

        [Required(ErrorMessage = "Informe o Bairro")]
        [MaxLength(100, ErrorMessage = "O campo {0} deve ter no máximo {1} caracteres")]
        public string Bairro { get; set; }

        [Required(ErrorMessage = "Informe o Número")]
        public int Numero { get; set; }

        [Required(ErrorMessage = "Informe a Cidade")]
        [MaxLength(100, ErrorMessage = "O campo {0} deve ter no máximo {1} caracteres")]
        public string Cidade { get; set; }

        [Required(ErrorMessage = "Informe o Estado")]
        [MaxLength(100, ErrorMessage = "O campo {0} deve ter no máximo {1} caracteres")]
        public string UF { get; set; }

        [MaxLength(100, ErrorMessage = "O campo {0} deve ter no máximo {1} caracteres")]
        public string Pais { get; set; }

        [Required(ErrorMessage = "Informe o dia da reunião")]
        [Display(Name = "Dia da Reunião")]
        public string DiaReuniao { get; set; }

        [Required(ErrorMessage = "Informe horário da reunião")]
        [Display(Name = "Horário da Reunião")]
        public string HoraReuniao { get; set; }

        [Required(ErrorMessage = "Informe a data de criação da célula")]
        [Display(Name = "Data de Criação")]
        public string DataCriacao { get; set; }

        [Required(ErrorMessage = "Informe telefones de contato")]
        [Display(Name = "Telefones de Contato")]
        public string Telefone1 { get; set; }
        public string Telefine2 { get; set; }
    }
}
