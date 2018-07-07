
using AutoMapper;
using bie.evgestao.application.Interfaces;
using bie.evgestao.domain.Entities;
using bie.evgestao.domain.Enums;
using bie.evgestao.ui.viewmodels;
using System;
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
        //Retorna somente a view pois a mesma usa uma chamada ajax pra popular o grid
        [Authorize]
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

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Superadmin,Administrador,Secretaria")]
        public ActionResult Criar(CelulaViewmodel model)
        {
            try
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

                //seta a mensagem de sucesso que será exibido pelo javascript
                ViewBag.Mensagem = "Item criado com sucesso";

                //retorna pra lista
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                //seta a mensagem de falha
                ViewBag.Mensagem = $"Erro ao processar o comando o erro foi: {ex.Message}";
                return View(model);
            }
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
            try
            {
                #region preparação
                ViewBag.PessoasDisponiveis = Mapper.Map<IEnumerable<Pessoa>, IEnumerable<PessoaViewmodel>>(_svcPessoa.GetAll());
                #endregion

                //valida se não há erros no modelstate (caso o jquery validation falhe)
                if (!ModelState.IsValid) return View(model);

                //carerga a entidade da celula no banco de dados
                var entidade = _svcCelula.GetById(model.id_celula);

                //faz um backup dos participantes pois o Automapper zera os itens filho que não encontrados
                var bkp_pessoas = entidade.Pessoas.ToList();

                //faz o mapeamento das propriedades 
                Mapper.Map<CelulaViewmodel, Celula>(model, entidade);

                //retorna alista de pessoas
                entidade.Pessoas = bkp_pessoas;

                //executa o update no banco 
                _svcCelula.Update(entidade);

                //retorna a mensagem de sucesso que será exibida pelo javascript 
                ViewBag.Mensagem = "Item modificado com sucesso";

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                //seta mensagem de falha
                ViewBag.Mensagem = $"Erro ao processar o comando o erro foi: {ex.Message}";
                return View(model);
            }

        }

        #endregion


        #region Visualizar 

        [Authorize]
        public ActionResult Celula(int id)
        {
            //Carrega a entidade do banco de dados 
            var objEntidade = _svcCelula.GetById(id);
            if (objEntidade == null) return new HttpNotFoundResult("Celula não encontrada");
            var model = Mapper.Map<Celula, CelulaViewmodel>(objEntidade);
            return View(model);
        }


        #endregion

        #region Participantes

        [HttpGet]
        [Authorize(Roles = "Superadmin,Administrador,Secretaria")]
        public ActionResult Participantes(int id)
        {

            #region preparação
            ViewBag.PessoasDisponiveis = Mapper.Map<IEnumerable<Pessoa>, IEnumerable<PessoaViewmodel>>(_svcPessoa.GetAll());

            var Situacoes = Helpers.EnumToDropDownListExtensions.GetSelectListFromEnum(SituacaoPessoa.COMUNGANTE);
            ViewBag.Situacoes = Situacoes;

            #endregion



            //carreg aa celula 
            var model = Mapper.Map<Celula, CelulaViewmodel>(_svcCelula.GetById(id));
            if (model == null) throw new HttpException(404, "Item não encontrado");

            return View(model);


        }

        #endregion



        #region Multiplicação 

        [HttpGet]
        [Authorize(Roles = "Superadmin,Administrador,Secretaria")]
        public ActionResult Multiplicar()
        {

            #region preparacao 


            //TODO: Gustavo. Verificar pois na regra de negócio nada impede o cara de ser coordenador de mais de uma celula
            var CelulasDisponiveis = from celula in _svcCelula.GetAll()
                                     where celula.Coordenador != null
                                     select new MultiplicarCelulasDisponiveisViewmodel
                                     {
                                         NomeCoordenador = celula.Coordenador.Nome,
                                         id_celula = celula.id_celula,
                                         NomeSupervisor = celula.Supervisor != null ? celula.Supervisor.Nome : string.Empty
                                     };

            ViewBag.CelulasDisponiveis = CelulasDisponiveis.ToArray();


            //lista as pessoas disponíveis para ser coordenador ou supervisor da nova célula
            ViewBag.PessoasDisponiveis = Mapper.Map<IEnumerable<Pessoa>, IEnumerable<PessoaViewmodel>>(_svcPessoa.GetAll());

            //carrega o ultimo numero de celula disponivel             
            var ProximaCelula = _svcCelula.GetAll().Last().id_celula + 1;
            ViewBag.ProximaCelula = ProximaCelula.ToString().PadLeft(4, '0');






            #endregion


            return View();
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
            try
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
            catch (Exception ex)
            {
                throw new HttpException(500, $"Erro ao executar o comando no servidor. o erro foi: {ex.Message}");
            }

        }

        [HttpPost]
        [Authorize(Roles = "Superadmin,Administrador,Secretaria")]
        public JsonResult DeletaParticipante(int id_celula, int id_participante)
        {
            try
            {
                //chama o serviço para remover o participante
                _svcCelula.DeletaParticipante(id_celula, id_participante);
                return Json("OK");
            }
            catch (Exception ex)
            {
                throw new HttpException(500, $"Erro ao executar o comando no servidor. o erro foi: {ex.Message}");
            }

        }


        [HttpPost]
        [Authorize(Roles = "Superadmin,Administrador,Secretaria")]
        public JsonResult AdicionarParticipante(int id_celula, int id_pessoa, SituacaoPessoa Situacao)
        {
            try
            {
                _svcCelula.InsereParticipante(id_celula, id_pessoa, Situacao);
                return Json("OK");
            }
            catch (Exception ex)
            {
                throw new HttpException(500, $"Erro ao executar o comando no servidor. o erro foi: {ex.Message}");
            }
        }

        [HttpPost]
        [Authorize(Roles = "Superadmin,Administrador,Secretaria")]
        public JsonResult Deletar(int id)
        {
            try
            {
                var celula = _svcCelula.GetById(id);

                if (celula == null) throw new HttpException(404, "Celula não encontrada");

                _svcCelula.Remove(celula);

                return Json("OK");
            }
            catch (Exception ex)
            {
                throw new HttpException(500, $"Erro ao executar o comando no servidor. o erro foi: {ex.Message}");
            }

        }


        #endregion



    }
}