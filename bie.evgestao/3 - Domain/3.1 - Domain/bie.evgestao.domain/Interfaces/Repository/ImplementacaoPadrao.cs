using bie.evgestao.domain.Entities;

namespace bie.evgestao.domain.Interfaces.Repository
{
    public interface IPessoaRepository : IRepositoryBase<Pessoa> { }
    public interface IFamiliarRepository : IRepositoryBase<Familiar> { }
    public interface ICelulaRepository : IRepositoryBase<Celula> { }
    public interface IFotoRepository : IRepositoryBase<Foto> { }

}
