

using bie.evgestao.domain.Entities;
using bie.evgestao.domain.Interfaces.Repository;
using bie.evgestao.domain.Interfaces.Service;

namespace bie.evgestao.domain.Services
{
    public class CelulaService : ServiceBase<Celula>, ICelulaService
    {
        private readonly ICelulaRepository _Repo;
        public CelulaService(ICelulaRepository Repo)
            : base(Repo)
        {
            _Repo = Repo;
        }

    }






}
