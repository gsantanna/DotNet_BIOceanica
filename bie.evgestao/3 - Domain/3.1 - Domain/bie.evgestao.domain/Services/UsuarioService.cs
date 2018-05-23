using System;
using bie.evgestao.domain.Entities;
using bie.evgestao.domain.Interfaces.Repository;
using bie.evgestao.domain.Interfaces.Service;

namespace bie.evgestao.domain.Services
{
    public class UsuarioService : ServiceBase<Usuario>, IUsuarioService
    {
        private readonly IUsuarioRepository _Repo;
        public UsuarioService(IUsuarioRepository Repo)
            : base(Repo)
        {
            _Repo = Repo;
        }

        public Usuario GetById(string id)
        {
            return _Repo.GetById(id);
        }
    }
}