using System.Collections.Generic;


namespace bie.evgestao.domain.Entities
{
    public class SituacaoPessoa
    {

        public int id_situacaopessoa { get; set; }

        public string Nome { get; set; }
        public string Tipo { get; set; }

        public virtual ICollection<Pessoa> Pessoas { get; set; }
    }


}
