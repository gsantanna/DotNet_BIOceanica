using bie.evgestao.application.Interfaces;
using bie.evgestao.domain.Entities;
using bie.evgestao.domain.Interfaces.Service;


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
    }


}
