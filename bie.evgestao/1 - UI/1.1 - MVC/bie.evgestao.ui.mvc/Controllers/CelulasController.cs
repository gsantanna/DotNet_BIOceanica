
using AutoMapper;
using bie.evgestao.application.Interfaces;
using bie.evgestao.domain.Entities;
using bie.evgestao.ui.viewmodels;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace bie.evgestao.ui.mvc.Controllers
{
    [Authorize]
    public class CelulasController : BaseController
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
        [Authorize(Roles = "Superadmin,Administrador,Secretaria")]
        public ActionResult Index()
        {
            return View();
        }



        #region Criar

        [HttpGet]
        [Authorize(Roles = "Superadmin,Administrador,Secretaria")]
        public ActionResult Criar()
        {
            #region preparação
            ViewBag.PessoasDisponiveis = Mapper.Map<IEnumerable<Pessoa>, IEnumerable<PessoaViewmodel>>(_svcPessoa.GetAll());
            #endregion

            //valida se não há erros no modelstate (caso o jquery validation falhe)



            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Superadmin,Administrador,Secretaria")]
        public ActionResult Criar(CelulaViewmodel model)
        {
            #region preparação
            ViewBag.PessoasDisponiveis = Mapper.Map<IEnumerable<Pessoa>, IEnumerable<PessoaViewmodel>>(_svcPessoa.GetAll());
            #endregion



            //valida se não há erros no modelstate (caso o jquery validation falhe)
            if (!ModelState.IsValid) return View(model);


            //mapeia a entidade
            var objEntidade = Mapper.Map<CelulaViewmodel, Celula>(model);

            //insere a entidade
            _svcCelula.Add(objEntidade);


            return View(model);
        }


        #endregion


        #region Editar

        [HttpGet]
        [Authorize(Roles = "Superadmin,Administrador,Secretaria")]
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
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Superadmin,Administrador,Secretaria")]
        public ActionResult Editar(CelulaViewmodel model)
        {
            #region preparação
            ViewBag.PessoasDisponiveis = Mapper.Map<IEnumerable<Pessoa>, IEnumerable<PessoaViewmodel>>(_svcPessoa.GetAll());
            #endregion

            //valida se não há erros no modelstate (caso o jquery validation falhe)
            if (!ModelState.IsValid) return View(model);


            var entidade = _svcCelula.GetById(model.id_celula);

            Mapper.Map<CelulaViewmodel, Celula>(model, entidade);

            _svcCelula.Update(entidade);

            ViewBag.Mensagem = "Item criado com sucesso";

            return RedirectToAction("Index");

        }

        #endregion





        #region Participantes

        [HttpGet]
        [Authorize(Roles = "Superadmin,Administrador,Secretaria")]
        public ActionResult Participantes(int id)
        {
            #region preparação
            ViewBag.PessoasDisponiveis = Mapper.Map<IEnumerable<Pessoa>, IEnumerable<PessoaViewmodel>>(_svcPessoa.GetAll());
            #endregion


            //carreg aa celula 
            var model = Mapper.Map<Celula, CelulaViewmodel>(_svcCelula.GetById(id));
            if (model == null) throw new HttpException(404, "Item não encontrado");

            return View(model);


        }

        [HttpPost]
        public ActionResult Participantes(CelulaViewmodel model)
        {
            return View(model);
        }

        #endregion








        #region API
        /// <summary>
        /// Método genérico para retornar a lista de itens da entidade para carregar a página inicial
        /// </summary>
        /// <returns></returns>
        /// 
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

        public JsonResult GetJsonParticipantes(int id)
        {
            //instancia as entidades já carregando do serviço 
            var entidade = _svcCelula.GetById(id);

            if (entidade == null) throw new HttpException(404, "Item não encontrado");


            //seleciona os campos necessários (performance)
            var model = Mapper.Map<IEnumerable<Pessoa>, IEnumerable<PessoaViewmodel>>(entidade.Pessoas).Select(x => new { x.id_pessoa, x.SituacaoDesc, x.Nome });


            //Retorna o tipo especial (JsonResult2) que é uma derivação do jsonresult tradicional, só que com um leve tratamento nas datas
            //para facilitar o uso no jquery datatables grid
            return new JsonResult2 { Data = new { data = model } };

        }


        public JsonResult DeletaParticipante(int id_celula, int id_participante)
        {
            //chama o serviço para remover o participante
            _svcCelula.DeletaParticipante(id_celula, id_participante);
            return Json("OK");

        }


        #endregion



    }
}