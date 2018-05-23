using bie.evgestao.domain.Enums;
using System;
using System.Collections.Generic;



namespace bie.evgestao.domain.Entities
{
    public partial class Pessoa
    {

        public int id_pessoa { get; set; }

        //Refencia da pessoa para célula ( Célula é pai da pessoa ) 
        public int id_celula { get; set; }
        public virtual Celula Celula { get; set; }

        //Situação da pessoa 
        public int id_situacaopessoa { get; set; }
        public SituacaoPessoa Situacao { get; set; }

        //Tipo de pessoa
        public int id_tipopessoa { get; set; }
        public TipoPessoa Tipo { get; set; }

        //Referencia da Pessoa ao Cargo
        public int id_cargo { get; set; }
        public virtual Cargo Cargo { get; set; }

        //Familiares
        public virtual ICollection<Familiar> Familiares { get; set; }

        public string Nome { get; set; }

        public int? Idade { get; set; }

        public string EstadoCivil { get; set; }

        public SEXO Sexo { get; set; }

        public string ConhecidoComo { get; set; }

        //Status de Ativo ou Não Ativo
        public bool Status { get; set; }

        public string TipoSanguineo { get; set; }

        public string endereco { get; set; }

        public string Bairro { get; set; }

        public string Numero { get; set; }

        public string Complemento  { get; set; }

        public string Cidade { get; set; }

        public string UF { get; set; }

        public string Pais { get; set; }

        public string Cep { get; set; }

        public string Telefone { get; set; }

        public string Email { get; set; }

        public string Profissao { get; set; }

        public string Naturalidade { get; set; }

        public string Nacionalidade { get; set; }
    }

}
