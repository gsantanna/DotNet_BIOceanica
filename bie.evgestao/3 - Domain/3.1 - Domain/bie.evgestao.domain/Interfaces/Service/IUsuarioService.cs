using bie.evgestao.domain.Entities;

namespace bie.evgestao.domain.Interfaces.Service
{
    public interface IUsuarioService : IServiceBase<Usuario>
    {
        Usuario GetById(string id);

    }
}