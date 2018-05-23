using System;
using System.Collections.Generic;

namespace bie.evgestao.domain.Entities
{
    public class Celula
    {

        public int id_celula { get; set; }

        public string Coordenador { get; set; }

        public string Supervidor { get; set; }

        public string Endereco { get; set; }

        public string Bairro { get; set; }

        public string Complemento { get; set; }

        public string Numero { get; set; }

        public string Cidade { get; set; }

        public string UF { get; set; }

        public string Pais { get; set; }

        public string DiaReuniao { get; set; }

        public string HoraReuniao { get; set; }

        public DateTime DataCriacao { get; set; }

        public string Telefone1 { get; set; }
        public string Telefine2 { get; set; }

        //Celula possui várias pessoas. logo...
        public virtual ICollection<Pessoa> Pessoas { get; set; }

        public int id_tipocelula { get; set; }
        public virtual TipoCelula TipoCelula { get; set; }

        

    }
}
