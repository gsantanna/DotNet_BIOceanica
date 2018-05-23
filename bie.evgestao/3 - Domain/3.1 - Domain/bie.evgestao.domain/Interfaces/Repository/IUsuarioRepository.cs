
using bie.evgestao.domain.Entities;

namespace bie.evgestao.domain.Interfaces.Repository
{
    public interface IUsuarioRepository : IRepositoryBase<Usuario>
    {

        Usuario GetById(string id);

    }
}