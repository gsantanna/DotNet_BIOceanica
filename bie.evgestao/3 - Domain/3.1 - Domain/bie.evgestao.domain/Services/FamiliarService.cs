

using bie.evgestao.domain.Entities;
using bie.evgestao.domain.Interfaces.Repository;
using bie.evgestao.domain.Interfaces.Service;

namespace bie.evgestao.domain.Services
{
    public class FamiliarService : ServiceBase<Familiar>, IFamiliarService
    {
        private readonly IFamiliarRepository _Repo;
        public FamiliarService(IFamiliarRepository Repo)
            : base(Repo)
        {
            _Repo = Repo;
        }

    }




}
