namespace bie.evgestao.domain.Entities
{
    public class HistoricoMovimentacao
    {
        public int id { get; set; }

        public int id_pessoa { get; set; }

        public virtual Pessoa Pessoa { get; set; }

        public System.DateTime Data { get; set; }

        public string Autor { get; set; }

        public string Movimento { get; set; }


    }

}
