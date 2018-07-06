using bie.evgestao.domain.Enums;
using System;
using System.Collections.Generic;

namespace bie.evgestao.domain.Entities
{
    public class Celula
    {

        public int id_celula { get; set; }


        public string Nome { get; set; }


        public virtual Pessoa Coordenador { get; set; }
        public virtual Pessoa Supervisor { get; set; }

        public int? id_coordenador { get; set; }
        public int? id_supervisor { get; set; }

        public string Cep { get; set; }
        public string Endereco { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }

        public EstadosBrasil UF { get; set; }

        public string Pais { get; set; }

        public DiasSemana DiaReuniao { get; set; }
        public string HoraReuniao { get; set; }
        public DateTime DataCriacao { get; set; }
        public string Telefone1 { get; set; }
        public string Telefone2 { get; set; }

        //Celula possui várias pessoas. logo...
        public virtual ICollection<Pessoa> Pessoas { get; set; }

        public TipoCelula TipoCelula { get; set; }

        public bool Ativo { get; set; }



    }
}
