using System.Collections.Generic;

namespace bie.evgestao.domain.Entities
{
    public partial class Pessoa
    {
        public class TipoPessoa
        {

            public int id_tipopessoa { get; set; }

            public string Nome { get; set; }
            public string Tipo { get; set; }
            public virtual ICollection<Pessoa> Pessoas { get; set; }

        }

    }

}
