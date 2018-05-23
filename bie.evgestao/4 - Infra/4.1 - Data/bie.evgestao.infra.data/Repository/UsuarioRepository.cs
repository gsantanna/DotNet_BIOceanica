using System.Linq;
using bie.evgestao.domain.Entities;
using bie.evgestao.domain.Interfaces.Repository;

namespace bie.evgestao.infra.data.Repository
{
    public class UsuarioRepository : RepositoryBase<Usuario>, IUsuarioRepository
    {
        public Usuario GetById(string id)
        {
            var resp = from u in Db.Set<Usuario>()
                       where u.id_usuario == id
                       select u;

            return resp.FirstOrDefault();

        }

    }
}