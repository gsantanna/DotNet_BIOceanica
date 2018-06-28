﻿

using bie.evgestao.domain.Entities;
using bie.evgestao.domain.Interfaces.Repository;

namespace bie.evgestao.infra.data.Repository
{
    public class PessoaRepository : RepositoryBase<Pessoa>, IPessoaRepository { }

    public class CelulaRepository : RepositoryBase<Celula>, ICelulaRepository { }

    public class FamiliarRepository : RepositoryBase<Familiar>, IFamiliarRepository { }

    public class FotoRepository : RepositoryBase<Foto>, IFotoRepository { }


}
