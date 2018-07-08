using bie.evgestao.domain.Enums;

namespace bie.evgestao.ui.viewmodels
{
    public class EnvioEmailPopupViewmodel
    {
        public int[] Destinatarios { get; set; }
        public string Titulo { get; set; }
        public string Mensagem { get; set; }
        public TipoEntregaNotificacao TipoEnvio { get; set; }
      

    }




}
