using System;
using bie.evgestao.application.Interfaces;
using bie.evgestao.domain.Entities;
using bie.evgestao.domain.Interfaces.Service;

namespace bie.evgestao.application
{
    public class UsuarioAppService : AppServiceBase<Usuario>, IUsuarioAppService
    {
        private readonly IUsuarioService _svc;
        public UsuarioAppService(IUsuarioService Svc)
            : base(Svc)
        {
            _svc = Svc;
        }

        public Usuario GetById(string id)
        {
            return _svc.GetById(id);
        }
    }
}