

using bie.evgestao.domain.Entities;
using bie.evgestao.domain.Interfaces.Repository;
using bie.evgestao.domain.Interfaces.Service;

namespace bie.evgestao.domain.Services
{
    public class PessoaService : ServiceBase<Pessoa>, IPessoaService
    {
        private readonly IPessoaRepository _Repo;
        public PessoaService(IPessoaRepository Repo)
            : base(Repo)
        {
            _Repo = Repo;
        }

    }






}
