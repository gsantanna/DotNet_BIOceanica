using System;
using bie.evgestao.application.Interfaces;
using bie.evgestao.domain.Entities;
using bie.evgestao.domain.Enums;
using bie.evgestao.domain.Interfaces.Service;


namespace bie.evgestao.application
{
    public class CelulaAppService : AppServiceBase<Celula>, ICelulaAppService
    {
        private readonly ICelulaService _svc;
        private readonly IPessoaService _svc_pessoa;
        public CelulaAppService(ICelulaService Svc, IPessoaService Svc2)
            : base(Svc)
        {
            _svc = Svc;
            _svc_pessoa = Svc2;
        }



        public void DeletaParticipante(int id_celula, int id_pessoa)
        {

            //encontra a pessoa 
            var pessoa = _svc_pessoa.GetById(id_pessoa);
            pessoa.id_celula = null;
            pessoa.Celula = null;
            _svc_pessoa.Update(pessoa);

        }

        public void InsereParticipante(int id_celula, int id_pessoa, SituacaoPessoa Situacao)
        {
            //encontra a pessoa 
            var pessoa = _svc_pessoa.GetById(id_pessoa);
            pessoa.id_celula = id_celula;
            pessoa.Situacao = Situacao;
            _svc_pessoa.Update(pessoa);

        }
    }


}
