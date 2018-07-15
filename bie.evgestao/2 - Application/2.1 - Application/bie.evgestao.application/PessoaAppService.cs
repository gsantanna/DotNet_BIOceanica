using bie.evgestao.application.Interfaces;
using bie.evgestao.domain.Entities;
using bie.evgestao.domain.Interfaces.Service;
using System.Web;

namespace bie.evgestao.application
{
    public class PessoaAppService : AppServiceBase<Pessoa>, IPessoaAppService
    {
        private readonly IPessoaService _svc;
        public PessoaAppService(IPessoaService Svc)
            : base(Svc)
        {
            _svc = Svc;
        }




        public new void Update(Pessoa obj)
        {

            //verifica se houve mudança nos campos entrada e saida
            //carrega o item original 
            var original = _svc.GetById(obj.id_pessoa);


            obj.Historico = original.Historico;

            var usuarioAtual = HttpContext.Current.User.Identity.Name;


            if (original.Entrada != obj.Entrada)
            {
                obj.Historico.Add(new HistoricoMovimentacao
                {
                    Autor = usuarioAtual,
                    Data = System.DateTime.Now,
                    id_pessoa = obj.id_pessoa,
                    Movimento = $"Entrada modificada de: {original.Entrada} para: {obj.Entrada}"
                });
            }




            if (original.Saida != obj.Saida)
            {
                obj.Historico.Add(new HistoricoMovimentacao
                {
                    Autor = usuarioAtual,
                    Data = System.DateTime.Now,
                    id_pessoa = obj.id_pessoa,
                    Movimento = $"Saída modificada de: {original.Saida} para: {obj.Saida}"
                });
            }


            _svc.Update(obj);
        }










    }


}
