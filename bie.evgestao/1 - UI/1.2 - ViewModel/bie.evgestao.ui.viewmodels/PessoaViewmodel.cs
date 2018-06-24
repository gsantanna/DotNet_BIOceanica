using bie.evgestao.domain.Enums;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace bie.evgestao.ui.viewmodels
{
    public class PessoaViewmodel
    {

        public int id_pessoa { get; set; }

        [Required(ErrorMessage = "Informe o Nome Completo")]
        [MaxLength(100, ErrorMessage = "O campo {0} deve ter no máximo {1} caracteres")]
        public string Nome { get; set; }

        [Display(Name = "Conhecido Como")]
        [MaxLength(100, ErrorMessage = "O campo {0} deve ter no máximo {1} caracteres")]
        public string ConhecidoComo { get; set; }




        [Required(ErrorMessage = "Informe o Sexo")]
        public SexoPessoa? Sexo { get; set; }

        [Display(Name = "Data de nascimento")]
        public DateTime? DataNascimento { get; set; }



        [MaxLength(250, ErrorMessage = "O campo {0} deve ter no máximo {1} caracteres")]
        public string Endereco { get; set; }


        [MaxLength(10, ErrorMessage = "O campo {0} deve ter no máximo {1} caracteres")]
        public string Numero { get; set; }

        [MaxLength(50, ErrorMessage = "O campo {0} deve ter no máximo {1} caracteres")]
        public string Complemento { get; set; }

        [MaxLength(100, ErrorMessage = "O campo {0} deve ter no máximo {1} caracteres")]
        public string Bairro { get; set; }

        [MaxLength(100, ErrorMessage = "O campo {0} deve ter no máximo {1} caracteres")]
        public string Cidade { get; set; }

        [MaxLength(2, ErrorMessage = "O campo {0} deve ter no máximo {1} caracteres")]
        public string UF { get; set; }

        [MaxLength(100, ErrorMessage = "O campo {0} deve ter no máximo {1} caracteres")]
        public string Pais { get; set; }

        [MaxLength(10, ErrorMessage = "O campo {0} deve ter no máximo {1} caracteres")]
        public string Cep { get; set; }


        [MaxLength(15, ErrorMessage = "O campo {0} deve ter no máximo {1} caracteres")]
        public string Telefone { get; set; }

        [MaxLength(15, ErrorMessage = "O campo {0} deve ter no máximo {1} caracteres")]
        [Display(Name = "Telefone Trabalho")]
        public string TelefoneTrabalho { get; set; }

        [MaxLength(15, ErrorMessage = "O campo {0} deve ter no máximo {1} caracteres")]
        [Display(Name = "Celular")]
        public string TelefoneCelular { get; set; }


        //        [Required(ErrorMessage = "Informe Endereço de E-Mail")]
        [MaxLength(100, ErrorMessage = "O campo {0} deve ter no máximo {1} caracteres")]
        [EmailAddress(ErrorMessage = "Preencha Email Válido")]
        [DisplayName("E-Mail")]
        public string Email { get; set; }



        [Display(Name = "Estado Civil")]
        public EstadoCivilPessoa? EstadoCivil { get; set; }

        [Display(Name = "Tipo Sanguíneo")]
        public TipoSanguineoPessoa TipoSanguineo { get; set; }

        [MaxLength(100, ErrorMessage = "O campo {0} deve ter no máximo {1} caracteres")]
        public string Naturalidade { get; set; }

        [MaxLength(100, ErrorMessage = "O campo {0} deve ter no máximo {1} caracteres")]
        public string Nacionalidade { get; set; }

        public SituacaoPessoa? Situacao { get; set; }

        public TipoEntradaPessoa? Entrada { get; set; }

        public TipoSaidaPessoa? Saida { get; set; }

        public FuncaoPessoa? Funcao { get; set; }



    }
}
