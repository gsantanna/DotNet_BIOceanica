


using bie.evgestao.domain.Entities;
using bie.evgestao.domain.Enums;

namespace bie.evgestao.application.Interfaces
{

    public interface ICelulaAppService : IAppServiceBase<Celula>
    {

        void DeletaParticipante(int id_celula, int id_pessoa);

        void InsereParticipante(int id_celula, int id_pessoa, SituacaoPessoa Situacao);





    }

}