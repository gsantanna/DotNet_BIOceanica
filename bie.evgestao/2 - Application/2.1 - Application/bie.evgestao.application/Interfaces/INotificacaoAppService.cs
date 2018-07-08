using bie.evgestao.domain.Entities;
using bie.evgestao.domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bie.evgestao.application.Interfaces
{
    public interface INotificationAppService
    {
        //disparar notificações
        Task<RespostaNotificacao> DispararNotificacaoAsync(Notification objNotific, TipoEntregaNotificacao tipoEntrega = TipoEntregaNotificacao.Email, string nomeTemplate = "base");



    }
}
