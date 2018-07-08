using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using bie.evgestao.application.Interfaces;
using AutoMapper;
using bie.evgestao.domain.Entities;
using bie.evgestao.ui.viewmodels;
using System.Web;
using bie.evgestao.domain.Enums;
using System.Threading.Tasks;

namespace bie.evgestao.ui.mvc.Controllers
{
    public class HomeController : BaseController
    {
        private readonly IPessoaAppService _svc_pessoa;
        private readonly INotificationAppService _svc_notificacao;

        public HomeController(IPessoaAppService Svc1, INotificationAppService Svc2)
        {
            _svc_pessoa = Svc1;
            _svc_notificacao = Svc2;
        }

        public ActionResult Index()
        {

            //Carrega os aniversariantes no banco de dados 
            var entAniv = from p in _svc_pessoa.GetAll()
                          where p.DataNascimento.HasValue && p.DataNascimento.Value.Day == DateTime.Now.Day && p.DataNascimento.Value.Month == DateTime.Now.Month
                          select p;

            var model = Mapper.Map<IEnumerable<Pessoa>, IEnumerable<PessoaViewmodel>>(entAniv);

            return View(model);
        }

        [Authorize]
        public async Task<JsonResult> Email(EnvioEmailPopupViewmodel model)
        {
            if (model.Destinatarios.Count() == 0) throw new HttpException(500, "é encessário selecionar pelo menos um destinatário");
            if (string.IsNullOrWhiteSpace(model.Mensagem) || string.IsNullOrWhiteSpace(model.Titulo)) throw new HttpException(400, "não é possível enviar mensagens vazias");


            //carrega os destinatários 
            var entidadesDestino = new List<Pessoa>();

            foreach (var dest in model.Destinatarios)
            {
                entidadesDestino.Add(_svc_pessoa.GetById(dest));
            }


            var notificacao = new Notification
            {                
                Assunto = model.Titulo,
                Destinatarios = entidadesDestino.Where(x => !string.IsNullOrEmpty(x.Email)).Select(x => x.Email).ToList(),
                Mensagem = model.Mensagem
            };

            try
            {
                //dispara um parallel foreach pra enviar rápido
                await _svc_notificacao.DispararNotificacaoAsync(notificacao, model.TipoEnvio,
                        "pendencia");
            }
            catch (Exception ex)
            {
                throw new HttpException(500, "Erro ao enviar a mensagem. o erro foi: " + ex.Message);
            }

            return Json("OK");

        }







    }
}