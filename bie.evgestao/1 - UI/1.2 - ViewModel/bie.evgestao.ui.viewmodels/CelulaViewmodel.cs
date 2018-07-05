using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using bie.evgestao.domain.Enums;
using System.ComponentModel;

namespace bie.evgestao.ui.viewmodels
{
    public class CelulaViewmodel
    {

        public string id_celula { get; set; }


        [Required(ErrorMessage = "Informe um nome para a célula")]
        [MaxLength(100, ErrorMessage = "O campo {0} deve ter no máximo {1} caracteres")]
        public string Nome { get; set; }



        public PessoaViewmodel Coordenador { get; set; }

        public PessoaViewmodel Supervisor { get; set; }


        [Required(ErrorMessage = "Selecione o coordenador da célula")]
        [Display(Name = "Coordenador")]
        public int id_coordenador { get; set; }


        [Display(Name = "Supervisor")]
        public int? id_supervisor { get; set; }




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
        public DiasSemana DiaReuniao { get; set; }

        public string DiaReuniaoDesc => DiaReuniao.ToDescriptionString();

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
        public string Telefone2 { get; set; }


        [Display(Name = "Tipo de célula")]
        [Required(ErrorMessage = "Informe o tipo de célula")]
        public TipoCelula TipoCelula { get; set; }

        #region colunas_formula
        public string TipoDesc => this.TipoCelula.ToDescriptionString();

        public string NomeCoordenador => this.Coordenador != null ? Coordenador.Nome : string.Empty;
        public string NomeSupervisor => this.Supervisor != null ? Supervisor.Nome : string.Empty;


        public bool Situacao { get; set; }

        public string SituacaoDesc => Situacao ? "Ativa" : "Inativa";

        public string Tels => $"{Telefone1}<br/>{Telefone2}";



        #endregion


    }
}
