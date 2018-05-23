namespace bie.evgestao.domain.Entities
{
    public class Familiar
    {     
        public int id_familiar { get; set; }
        public string Nome { get; set; }

        public int id_pessoa { get; set; }
        public virtual Pessoa Pessoa { get; set; }

        public int id_grauparentesco { get; set; }
        public GrauParentesco Parentesco { get; set; }        
    }
}
