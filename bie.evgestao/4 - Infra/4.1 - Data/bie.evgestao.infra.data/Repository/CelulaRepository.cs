
using System.Linq;
using System.Collections.Generic;
using bie.evgestao.domain.Entities;
using bie.evgestao.domain.Interfaces.Repository;

namespace bie.evgestao.infra.data.Repository
{
    public class CelulaRepository : RepositoryBase<Celula>, ICelulaRepository
    {


        public new void Remove(Celula obj)
        {
            //            var entidade = Db.Set<Anexo>().Find(anexo.id_anexo);


            foreach (var p in obj.Pessoas.ToList())
            {
                var pessoa = Db.Set<Pessoa>().Find(p.id_pessoa);
                pessoa.id_celula = null;
                pessoa.Celula = null;
            }

            Db.SaveChanges();


            Db.Set<Celula>().Remove(obj);
            Db.SaveChanges();



        }




    }






}
