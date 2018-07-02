using bie.evgestao.application.Interfaces;
using bie.evgestao.domain.Entities;
using bie.evgestao.domain.Interfaces.Service;


namespace bie.evgestao.application
{
    public class CelulaAppService : AppServiceBase<Celula>, ICelulaAppService
    {
        private readonly ICelulaService _svc;
        public CelulaAppService(ICelulaService Svc)
            : base(Svc)
        {
            _svc = Svc;
        }
    }


}
