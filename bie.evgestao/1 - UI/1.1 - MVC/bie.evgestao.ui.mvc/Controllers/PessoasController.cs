using AutoMapper;
using bie.evgestao.application.Interfaces;
using bie.evgestao.domain.Entities;
using bie.evgestao.ui.viewmodels;
using System.Collections.Generic;
using System.Web.Mvc;
using System;
using System.Web;
using System.Linq;
using bie.evgestao.domain.Enums;

namespace bie.evgestao.ui.mvc.Controllers
{
    [Authorize]
    public class PessoasController : BaseController
    {


        private readonly IPessoaAppService _svcPessoa;
        private readonly IFamiliarAppService _svcFamiliar;



        //Constructor que atravé da injeção de dependencias já vai receber uma instancia da classe de serviço apropriada
        public PessoasController(IPessoaAppService Svc1, IFamiliarAppService Svc2)
        {
            _svcPessoa = Svc1;
            _svcFamiliar = Svc2;

        }

        // GET: Pessoas
        //Retorna somente a view pois a mesma usa uma chamada ajax pra popular o grid
        public ActionResult Index()
        {
            return View();
        }

        #region Criar 
        [HttpGet]
        [Authorize(Roles = "Superadmin,Administrador,Secretaria")]
        public ActionResult Criar()
        {
            return View();

        }

        [HttpPost]
        [Authorize(Roles = "Superadmin,Administrador,Secretaria")]
        [ValidateAntiForgeryToken]
        public ActionResult Criar(PessoaViewmodel model)
        {
            try
            {

                //valida se não há erros no modelstate (caso o jquery validation falhe)
                if (!ModelState.IsValid) return View(model);

                //Cria a entidade de banco de dados através do viewmodel usando o AutoMapper
                Pessoa objEntidade = Mapper.Map<PessoaViewmodel, Pessoa>(model);



                //carrega os dados da foto
                //somente se o usuário fez upload da foto, pois caso não tenha feito, não modificará a imagem 
                //atualmente gravada no banco de dados
                if (model.ArqImagem != null && model.ArqImagem.ContentLength > 0)
                {
                    //carrega o mime type do arquivo. Será necessário para entregar o arquivo via FileResult
                    objEntidade.FotoMime = model.ArqImagem.ContentType;

                    //cria o array vazio com o tamanho exato da imagem que foi feito upload 
                    objEntidade.Foto = new byte[model.ArqImagem.ContentLength];

                    //lê os bytes do arquivo que foi feito upload e grava na entidade do banco de dados 
                    model.ArqImagem.InputStream.Read(objEntidade.Foto, 0, objEntidade.Foto.Length);
                }


                //Chama o serviço para adicionar a entidade Pessoa recém declarada 
                _svcPessoa.Add(objEntidade);

                //Seta a mensagem de retorno (javascript na página de layout)
                ViewBag.Mensagem = "Item criado com sucesso";

                //redireciona para o index
                return RedirectToAction("Index");
            }
            catch (Exception ex) //tratado aqui caso de erro o usuário não perde o preenchimento pois ele tem o return view(model)
            {
                ViewBag.Mensagem = $"Erro ao executar o comando. O erro foi: {ex.Message}";
                //TODO: Logar o erro no log4net
                return View(model);

            }




        }

        #endregion


        #region Visualizar  
        [Authorize]
        public ActionResult pessoa(int id)
        {
            #region preparação 

            //Carrega a entidade do banco de dados 
            var objEntidade = _svcPessoa.GetById(id);
            if (objEntidade == null) return new HttpNotFoundResult("Pessoa não encontrada");
            PessoaViewmodel model = Mapper.Map<Pessoa, PessoaViewmodel>(objEntidade);
            #endregion

            return View(model);

        }

        #endregion


        #region Editar 

        [HttpGet]
        [Authorize(Roles = "Superadmin,Administrador,Secretaria")]
        public ActionResult Editar(int id)
        {
            #region preparação 

            //Carrega a entidade do banco de dados 
            var objEntidade = _svcPessoa.GetById(id);
            if (objEntidade == null) return new HttpNotFoundResult("Pessoa não encontrada");
            PessoaViewmodel model = Mapper.Map<Pessoa, PessoaViewmodel>(objEntidade);
            #endregion

            return View(model);



        }


        [HttpPost]
        [Authorize(Roles = "Superadmin,Administrador,Secretaria")]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(PessoaViewmodel model)
        {
            try
            {
                //valida se não há erros no modelstate (caso o jquery validation falhe)
                if (!ModelState.IsValid) return View(model);


                //Carrega a entidade do banco de dados 
                var objEntidade = _svcPessoa.GetById(model.id_pessoa);
                if (objEntidade == null) return new HttpNotFoundResult("Pessoa não encontrada");

                //faz backup dos familiares
                var FamiliaresBak = objEntidade.Familiares.ToList();


                //remapeia as propriedades para atualizar o banco (atualiza as propriedades da entidade do banco de dados com os dados da viewmodel)
                Mapper.Map<PessoaViewmodel, Pessoa>(model, objEntidade);

                objEntidade.Familiares = FamiliaresBak;






                //carrega os dados da foto
                //somente se o usuário fez upload da foto, pois caso não tenha feito, não modificará a imagem 
                //atualmente gravada no banco de dados
                if (model.ArqImagem != null && model.ArqImagem.ContentLength > 0)
                {
                    //carrega o mime type do arquivo. Será necessário para entregar o arquivo via FileResult
                    objEntidade.FotoMime = model.ArqImagem.ContentType;

                    //cria o array vazio com o tamanho exato da imagem que foi feito upload 
                    objEntidade.Foto = new byte[model.ArqImagem.ContentLength];

                    //lê os bytes do arquivo que foi feito upload e grava na entidade do banco de dados 
                    model.ArqImagem.InputStream.Read(objEntidade.Foto, 0, objEntidade.Foto.Length);
                }



                //Atualiza os dados no banco (executa a chamada do application pra atualizar a pessoa 
                _svcPessoa.Update(objEntidade);

                //TODO:Logar no audit trail a alteração

                //cria a mensagem de retorno 
                ViewBag.Mensagem = $"Membro {objEntidade.Nome} atualizado com sucesso!";


                //retorna para a view (index) 
                return RedirectToAction("Index");



            }
            catch (Exception ex)
            {
                ViewBag.Mensagem = $"Erro ao executar o comando. O erro foi: {ex.Message}";
                //TODO: Logar o erro no log4net
                return View(model);


            }


        }




        #endregion

        #region Deletar 

        [Authorize(Roles = "Superadmin,Administrador,Secretaria")]
        public JsonResult Deletar(int id)
        {
            try
            {
                //Carrega o modelo do banco de dados com o ID referente ao que está sendo solicitado para deleção 
                var model = _svcPessoa.GetById(id);

                //Caso não encontre retorna uma exception 
                if (model == null) throw new HttpException(404, "Item não encontrado");

                //Passa o comando para a camada de aplicação remover a pessoa do sistema
                _svcPessoa.Remove(model);

                //retorna um status OK 
                return Json("OK");
            }
            catch (Exception ex)
            {
                //caso dê algum erro ele retorna um erro HTTP para o ajax falhar e o javascript poder tratar a mensagem pro usuário
                throw new HttpException(500, $"Erro ao excluir a pessoa. O erro foi: {ex.Message}");
            }
        }


        #endregion

        #region Familiares
        [Authorize]
        public ActionResult Familiares(int id)
        {

            #region preparação 
            //Carrega a entidade do banco de dados 
            var objEntidade = _svcPessoa.GetById(id);
            if (objEntidade == null) return new HttpNotFoundResult("Pessoa não encontrada");
            PessoaViewmodel model = Mapper.Map<Pessoa, PessoaViewmodel>(objEntidade);

            var Parentescos = Helpers.EnumToDropDownListExtensions.GetSelectListFromEnum((new FamiliarViewmodel()).Parentesco);
            Parentescos.Last().Selected = true;
            ViewBag.Parentescos = Parentescos;

            #endregion

            return View(model);
        }


        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Superadmin,Administrador,Secretaria")]
        public JsonResult AdicionarFamiliar(FamiliarViewmodel model)
        {
            //Encontra a pessoa.
            var entidadePessoa = _svcPessoa.GetById(model.id_pessoa);
            var objEntidade = Mapper.Map<FamiliarViewmodel, Familiar>(model);
            entidadePessoa.Familiares.Add(objEntidade);
            _svcPessoa.Update(entidadePessoa);

            return new JsonResult2 { Data = new { data = model } };
        }




        [Authorize(Roles = "Superadmin,Administrador,Secretaria")]
        public JsonResult DeletarFamiliar(int id)
        {
            try
            {
                //Carrega o modelo do banco de dados com o ID referente ao que está sendo solicitado para deleção 
                var model = _svcFamiliar.GetById(id);

                //Caso não encontre retorna uma exception 
                if (model == null) throw new HttpException(404, "Item não encontrado");

                //Passa o comando para a camada de aplicação remover a pessoa do sistema
                _svcFamiliar.Remove(model);

                //retorna um status OK 
                return Json("OK");
            }
            catch (Exception ex)
            {
                //caso dê algum erro ele retorna um erro HTTP para o ajax falhar e o javascript poder tratar a mensagem pro usuário
                throw new HttpException(500, $"Erro ao excluir o familiar. O erro foi: {ex.Message}");
            }
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
            var entidade = _svcPessoa.GetAll();
            //Mapeia para a viewmodel --> não se deve retornar o modelo direto sem uma viewmodel pois como ele tem muitos relacionamentos, pode arriscar
            //carregar todos os dados do sistema no mesmo ajax, o que travaria o navegador e o servidor 
            var model = Mapper.Map<IEnumerable<Pessoa>, IEnumerable<PessoaViewmodel>>(entidade);

            //Retorna o tipo especial (JsonResult2) que é uma derivação do jsonresult tradicional, só que com um leve tratamento nas datas
            //para facilitar o uso no jquery datatables grid
            return new JsonResult2 { Data = new { data = model } };
        }

        //getJsonFamiliares

        public JsonResult GetJsonFamiliares(int id)
        {
            //carrega a pessoa no banco de dados
            var entidade = _svcPessoa.GetById(id);
            var model = Mapper.Map<IEnumerable<Familiar>, IEnumerable<FamiliarViewmodel>>(entidade.Familiares);
            return new JsonResult2 { Data = new { data = model } };
        }



        public FileResult Foto(int id)
        {
            //carrega a entidade 
            var entidade = _svcPessoa.GetById(id);

            //caso não encontre a entidade ele retorna um erro 404 
            if (entidade == null) throw new HttpException(404, "Imagem não localizada");


            //caso não tenha foto retorna o placeholder
            if (entidade.Foto == null || entidade.Foto.Length == 0)
            {
                return File(
                    System.IO.File.ReadAllBytes(Server.MapPath("~/Content/pessoa.png"))
                    , System.Net.Mime.MediaTypeNames.Application.Octet, "pessoa.png");
            }

            //carrega a extensão do arquivo pelo mime type
            var ext = "bmp";
            if (entidade.FotoMime.Contains("jpg") || entidade.FotoMime.Contains("jpeg")) ext = "jpg";
            if (entidade.FotoMime.Contains("png") || entidade.FotoMime.Contains("portable")) ext = "png";
            if (entidade.FotoMime.Contains("gif")) ext = "gif";

            //retorna o arquivo do banco de dados
            return File(entidade.Foto, entidade.FotoMime, $"{entidade.Nome}.{ext}");

        }

        #endregion


    }
}