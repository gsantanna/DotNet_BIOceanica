using System.Collections.Generic;

namespace bie.evgestao.domain.Entities
{
    public class TipoCelula
    {

        public int id_tipocelula { get; set; }

        public string Tipo { get; set; }

        public virtual ICollection<Celula> Celulas { get; set; }



    }


}
