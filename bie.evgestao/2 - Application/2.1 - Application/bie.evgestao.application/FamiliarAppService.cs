using bie.evgestao.application.Interfaces;
using bie.evgestao.domain.Entities;
using bie.evgestao.domain.Interfaces.Service;


namespace bie.evgestao.application
{
    public class FamiliarAppService : AppServiceBase<Familiar>, IFamiliarAppService
    {
        private readonly IFamiliarService _svc;
        public FamiliarAppService(IFamiliarService Svc)
            : base(Svc)
        {
            _svc = Svc;
        }
    }


}
