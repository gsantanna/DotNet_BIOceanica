
using System;
using System.IO;
using System.Threading.Tasks;
using bie.evgestao.application.Interfaces;
using bie.evgestao.domain.Entities;
using bie.evgestao.domain.Enums;
using bie.evgestao.infra.emailservice;
using System.Web;


namespace bie.evgestao.application
{
    public class NotificationAppService : INotificationAppService
    {

        private readonly EmailService _MailSvc;

        public NotificationAppService()
        {
            _MailSvc = new EmailService();
        }

        public async Task<RespostaNotificacao> DispararNotificacaoAsync(Notification objNotific, TipoEntregaNotificacao tipoEntrega = TipoEntregaNotificacao.Email, string nomeTemplate = "base")
        {

            var strCorpo = string.Empty;

            if (tipoEntrega == TipoEntregaNotificacao.Email)
            {
                strCorpo = objNotific.Mensagem;
            }
            else
            {
                throw new NotImplementedException();
            }

            //substitui os valores 
            foreach (var valor in objNotific.Valores)
            {
                strCorpo = strCorpo.Replace("{{" + valor.Chave + "}}", valor.Valor);
            }

            foreach (var item in objNotific.Destinatarios)
            {
                await _MailSvc.SendAsyncRegular(item, objNotific.Assunto, strCorpo);
            }

            return RespostaNotificacao.Sucesso;



        }
    }
}
