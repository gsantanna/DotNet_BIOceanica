using bie.evgestao.domain.Entities;

namespace bie.evgestao.application.Interfaces
{
    public interface IUsuarioAppService : IAppServiceBase<Usuario>
    {
        Usuario GetById(string id);
    }
}