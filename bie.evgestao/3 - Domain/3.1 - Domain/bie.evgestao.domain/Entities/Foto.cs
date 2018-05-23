namespace bie.evgestao.domain.Entities
{
    public class Foto
    {

        public int id_foto { get; set; }

        public byte[] ArquivoFoto { get; set; }

        public string Mime { get; set; }

        public double Tamanho { get; set; }
    }
}
