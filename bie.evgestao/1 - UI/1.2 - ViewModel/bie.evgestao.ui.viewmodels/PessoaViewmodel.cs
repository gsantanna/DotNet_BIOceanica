using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using static bie.evgestao.domain.Entities.Pessoa;

namespace bie.evgestao.ui.viewmodels
{
    public class PessoaViewmodel
    {
        [Key]
        public int id_pessoa { get; set; }

        [Required(ErrorMessage = "Informe o Nome Completo")]
        [MaxLength(100, ErrorMessage = "O campo {0} deve ter no máximo {1} caracteres")]
        public string Nome { get; set; }

        //Tipo de pessoa
        [Required(ErrorMessage = "Informe Tipo de Pessoa")]
        [Display(Name = "Tipo de Pessoa")]
        public TipoPessoa Tipo { get; set; }

        //Status de Ativo ou Não Ativo
        public bool Status { get; set; }

        [Display(Name = "Tipo Sanguíneo")]
        public string TipoSanguineo { get; set; }

        [Required(ErrorMessage = "Informe Estado Civil")]
        [Display(Name = "Estado Civil")]
        public string EstadoCivil { get; set; }

        [Required(ErrorMessage = "Informe o Cargo da Pessoa")]
        [Display(Name = "Cargo")]
        public string CargoPessoa { get; set; }

        [Required(ErrorMessage = "Informe o Sexo")]
        public string Sexo { get; set; }

        [Required(ErrorMessage = "Informe a Idade")]
        public int Idade { get; set; }

        [Display(Name = "Conhecido Como")]
        [MaxLength(100, ErrorMessage = "O campo {0} deve ter no máximo {1} caracteres")]
        public string ConhecidoComo { get; set; }

        [Required(ErrorMessage = "Informe o Endereço")]
        [MaxLength(250, ErrorMessage = "O campo {0} deve ter no máximo {1} caracteres")]
        public string endereco { get; set; }

        [Required(ErrorMessage = "Informe o Bairro")]
        [MaxLength(100, ErrorMessage = "O campo {0} deve ter no máximo {1} caracteres")]
        public string Bairro { get; set; }

        [Required(ErrorMessage = "Informe o Número da Casa ou Apartamento")]
        public int Numero { get; set; }

        [Required(ErrorMessage = "Informe o Telefone de Contato")]
        public string Telefone { get; set; }

        [Required(ErrorMessage = "Informe a Cidade")]
        [MaxLength(100, ErrorMessage = "O campo {0} deve ter no máximo {1} caracteres")]
        public string Cidade { get; set; }

        [Required(ErrorMessage = "Informe o Estado")]
        public string UF { get; set; }

        public string Cep { get; set; }

        public string Pais { get; set; }

        [Required(ErrorMessage = "Informe Endereço de E-Mail")]
        [MaxLength(100, ErrorMessage = "O campo {0} deve ter no máximo {1} caracteres")]
        [EmailAddress(ErrorMessage ="Preencha Email Válido")]
        [DisplayName("E-Mail")]
        public string Email { get; set; }

        [MaxLength(100, ErrorMessage = "O campo {0} deve ter no máximo {1} caracteres")]
        public string Profissao { get; set; }

        [MaxLength(100, ErrorMessage = "O campo {0} deve ter no máximo {1} caracteres")]
        public string Naturalidade { get; set; }

        [MaxLength(100, ErrorMessage = "O campo {0} deve ter no máximo {1} caracteres")]
        public string Nacionalidade { get; set; }

        [Required(ErrorMessage = "Informe o Tipo de Pessoa")]
        public String TipoPessoa { get; set; }

        public int QtdFamiliares { get; set; }





    }
}
