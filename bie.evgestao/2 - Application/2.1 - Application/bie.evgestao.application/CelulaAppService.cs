using bie.evgestao.application.Interfaces;
using bie.evgestao.domain.Entities;
using bie.evgestao.domain.Interfaces.Service;


namespace bie.evgestao.application
{
    public class CelulaaAppService : AppServiceBase<Celula>, ICelulaAppService
    {
        private readonly ICelulaService _svc;
        public CelulaaAppService(ICelulaService Svc)
            : base(Svc)
        {
            _svc = Svc;
        }
    }


}
