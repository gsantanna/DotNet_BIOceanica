

using bie.evgestao.domain.Entities;
using bie.evgestao.domain.Interfaces.Repository;
using System.Linq;

namespace bie.evgestao.infra.data.Repository
{
    public class PessoaRepository : RepositoryBase<Pessoa>, IPessoaRepository
    {

        public new void Remove(Pessoa obj)
        {
            //remove antes os familiares
            foreach (var familiar in obj.Familiares.ToArray())
            {
                Db.Set<Familiar>().Remove(familiar);

            }
            Db.SaveChanges();

            Db.Set<Pessoa>().Remove(obj);
            Db.SaveChanges();




        }


    }

    public class CelulaRepository : RepositoryBase<Celula>, ICelulaRepository { }

    public class FamiliarRepository : RepositoryBase<Familiar>, IFamiliarRepository { }




}
