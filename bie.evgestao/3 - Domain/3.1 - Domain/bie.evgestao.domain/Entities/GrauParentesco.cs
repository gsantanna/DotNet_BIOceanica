using System.Collections.Generic;

namespace bie.evgestao.domain.Entities
{
    public class GrauParentesco
    {

        public int id_grauparentesco { get; set; }
        public string Nome { get; set; }
        public virtual ICollection<Familiar> Familiares { get; set; }

    }
}
