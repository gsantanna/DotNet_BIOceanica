
using AutoMapper;
using bie.evgestao.application.Interfaces;
using bie.evgestao.domain.Entities;
using bie.evgestao.ui.viewmodels;
using System.Collections.Generic;

using System.Web.Mvc;

namespace bie.evgestao.ui.mvc.Controllers
{
    public class CelulasController : Controller
    {

        #region Constructor 
        private readonly IPessoaAppService _svcPessoa;
        private readonly ICelulaAppService _svcCelula;

        public CelulasController(IPessoaAppService Svc1, ICelulaAppService Svc2)
        {
            _svcPessoa = Svc1;
            _svcCelula = Svc2;
        }

        #endregion




        // GET: Celula
        public ActionResult Index()
        {
            return View();
        }



        #region Criar

        [HttpGet]
        public ActionResult Criar()
        {
            #region preparação
            ViewBag.PessoasDisponiveis = Mapper.Map<IEnumerable<Pessoa>, IEnumerable<PessoaViewmodel>>(_svcPessoa.GetAll());
            #endregion

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Criar(CelulaViewmodel model)
        {
            #region preparação
            ViewBag.PessoasDisponiveis = Mapper.Map<IEnumerable<Pessoa>, IEnumerable<PessoaViewmodel>>(_svcPessoa.GetAll());
            #endregion


            //mapeia a entidade
            var objEntidade = Mapper.Map<CelulaViewmodel, Celula>(model);

            //insere a entidade
            _svcCelula.Add(objEntidade);


            return View(model);
        }




        #endregion


        #region Editar

        [HttpGet]
        public ActionResult Editar(int id)
        {
            #region preparação
            ViewBag.PessoasDisponiveis = Mapper.Map<IEnumerable<Pessoa>, IEnumerable<PessoaViewmodel>>(_svcPessoa.GetAll());
            #endregion

            var entidade = _svcCelula.GetById(id);

            var model = Mapper.Map<Celula, CelulaViewmodel>(entidade);


            return View(model);
        }


        [HttpPost]
        public ActionResult Editar(CelulaViewmodel model)
        {
            #region preparação
            ViewBag.PessoasDisponiveis = Mapper.Map<IEnumerable<Pessoa>, IEnumerable<PessoaViewmodel>>(_svcPessoa.GetAll());
            #endregion

            var entidade = _svcCelula.GetById(model.id_celula);

            Mapper.Map<CelulaViewmodel, Celula>(model, entidade);

            _svcCelula.Update(entidade);

            return RedirectToAction("Index");

        }

        #endregion











        #region API
        /// <summary>
        /// Método genérico para retornar a lista de itens da entidade para carregar a página inicial
        /// </summary>
        /// <returns></returns>
        public JsonResult GetJson()
        {
            //instancia as entidades já carregando do serviço 
            var entidade = _svcCelula.GetAll();
            //Mapeia para a viewmodel --> não se deve retornar o modelo direto sem uma viewmodel pois como ele tem muitos relacionamentos, pode arriscar
            //carregar todos os dados do sistema no mesmo ajax, o que travaria o navegador e o servidor 
            var model = Mapper.Map<IEnumerable<Celula>, IEnumerable<CelulaViewmodel>>(entidade);

            //Retorna o tipo especial (JsonResult2) que é uma derivação do jsonresult tradicional, só que com um leve tratamento nas datas
            //para facilitar o uso no jquery datatables grid
            return new JsonResult2 { Data = new { data = model } };
        }



        #endregion



    }
}