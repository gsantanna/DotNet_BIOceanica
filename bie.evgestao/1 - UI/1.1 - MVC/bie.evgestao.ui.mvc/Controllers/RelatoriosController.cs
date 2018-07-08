using AutoMapper;
using bie.evgestao.application.Interfaces;
using bie.evgestao.domain.Entities;
using bie.evgestao.ui.viewmodels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace bie.evgestao.ui.mvc.Controllers
{
    public class RelatoriosController : BaseController
    {
        private readonly ICelulaAppService _svc_celula;
        private readonly IPessoaAppService _svc_pessoa;

        public RelatoriosController(ICelulaAppService svc1, IPessoaAppService svc2)
        {
            _svc_celula = svc1;
            _svc_pessoa = svc2;

        }



        public ActionResult FichaCelula()
        {
            var model = Mapper.Map<IEnumerable<Celula>, IEnumerable<CelulaViewmodel>>(_svc_celula.GetAll());
            return View(model);
        }

        public ActionResult Aniversariantes(int? mes)
        {

            var model = Mapper.Map<IEnumerable<Pessoa>, IEnumerable<PessoaViewmodel>>(
               _svc_pessoa.GetAll().Where(x => x.DataNascimento.HasValue && x.DataNascimento.Value.Month == (mes.HasValue ? mes : x.DataNascimento.Value.Month))
               );

            return View(model);

        }

    }
}