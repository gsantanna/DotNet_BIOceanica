
using bie.evgestao.domain.Enums;
using System;
using System.Collections.Generic;



namespace bie.evgestao.domain.Entities
{
    public class Pessoa
    {
        public Pessoa()
        {
            Familiares = new List<Familiar>();
            Historico = new List<HistoricoMovimentacao>();
        }

        public int id_pessoa { get; set; }

        //Refencia da pessoa para célula ( Célula é pai da pessoa ) 
        public int? id_celula { get; set; } //opcional. A pessoa pode não estar em nenuhma célula
        public virtual Celula Celula { get; set; }


        public virtual ICollection<Celula> CelulasSupervisionadas { get; set; }

        public virtual ICollection<Celula> CelulasCoordenadas { get; set; }


        //Familiares
        public virtual ICollection<Familiar> Familiares { get; set; }


        public string Nome { get; set; }
        public string ConhecidoComo { get; set; }
        public SexoPessoa? Sexo { get; set; }

        public DateTime? DataNascimento { get; set; }


        public string Endereco { get; set; }

        public string Numero { get; set; }

        public string Complemento { get; set; }

        public string Bairro { get; set; }

        public string Cidade { get; set; }

        public EstadosBrasil UF { get; set; }

        public string Pais { get; set; }

        public string Cep { get; set; }



        public string Telefone { get; set; }
        public string TelefoneTrabalho { get; set; }
        public string TelefoneCelular { get; set; }

        public string Email { get; set; }

        public EstadoCivilPessoa? EstadoCivil { get; set; }

        public TipoSanguineoPessoa TipoSanguineo { get; set; }

        public string Naturalidade { get; set; }

        public string Nacionalidade { get; set; }

        public SituacaoPessoa? Situacao { get; set; }

        public TipoEntradaPessoa? Entrada { get; set; }

        public TipoSaidaPessoa? Saida { get; set; }

        public FuncaoPessoa Funcao { get; set; }

        public virtual ICollection<HistoricoMovimentacao> Historico { get; set; }


        //trazido para pessoa para simplificar. 
        //TODO: pode ser movido pra uma classe separada depois.
        public Byte[] Foto { get; set; }
        public string FotoMime { get; set; }

    }

}
