using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using bie.evgestao.domain.Enums;

namespace bie.evgestao.ui.viewmodels
{
    class CelulaViewmodel
    {
        [Key]
        public string id_celula { get; set; }


        [Required(ErrorMessage = "Selecione o coordenador da célula")]
        public PessoaViewmodel Coordenador { get; set; }


        public CelulaViewmodel Supervisor { get; set; }






        //public string Cep { get; set; }
        //public string Endereco { get; set; }
        //public string Numero { get; set; }
        //public string Complemento { get; set; }
        //public string Bairro { get; set; }
        //public string Cidade { get; set; }
        //public string UF { get; set; }
        //public string Pais { get; set; }



        [Required(ErrorMessage = "Informe o cep da Célula (somente números)")]
        [MaxLength(8, ErrorMessage = "O campo {0} deve ter no máximo {1} caracteres")]
        public string Cep { get; set; }

        [MaxLength(20, ErrorMessage = "O campo {0} deve ter no máximo {1} caracteres")]
        [Required(ErrorMessage = "Informe o Número da célula")]
        public string Numero { get; set; }

        [MaxLength(20, ErrorMessage = "O campo {0} deve ter no máximo {1} caracteres")]
        public string Complemento { get; set; }





        [Required(ErrorMessage = "Informe o Endereço da Célula")]
        [MaxLength(250, ErrorMessage = "O campo {0} deve ter no máximo {1} caracteres")]
        public string Endereco { get; set; }

        [Required(ErrorMessage = "Informe o Bairro")]
        [MaxLength(100, ErrorMessage = "O campo {0} deve ter no máximo {1} caracteres")]
        public string Bairro { get; set; }



        [Required(ErrorMessage = "Informe a Cidade")]
        [MaxLength(100, ErrorMessage = "O campo {0} deve ter no máximo {1} caracteres")]
        public string Cidade { get; set; }

        [Required(ErrorMessage = "Informe o Estado")]
        public EstadosBrasil UF { get; set; }

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
        public DateTime? DataCriacao { get; set; }

        [Required(ErrorMessage = "Informe telefones de contato")]
        [Display(Name = "Telefone")]
        public string Telefone1 { get; set; }

        [Display(Name = "Telefone Outro")]
        public string Telefine2 { get; set; }
    }
}
