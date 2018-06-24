using AutoMapper;
using bie.evgestao.application.Interfaces;
using bie.evgestao.domain.Entities;
using bie.evgestao.ui.viewmodels;
using System.Collections.Generic;
using System.Web.Mvc;

namespace bie.evgestao.ui.mvc.Controllers
{
    public class PessoasController : BaseController
    {


        private readonly IPessoaAppService _svcPessoa;



        public PessoasController(IPessoaAppService Svc1)
        {
            _svcPessoa = Svc1;

        }

        // GET: Pessoas
        public ActionResult Index()
        {
            return View();
        }











        #region API
        public JsonResult GetJson()
        {
            var entidade = _svcPessoa.GetAll();
            var model = Mapper.Map<IEnumerable<Pessoa>, IEnumerable<PessoaViewmodel>>(entidade);
            return new JsonResult2 { Data = new { data = model } };
        }


        #endregion


    }
}