using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using bie.evgestao.application.Interfaces;
using bie.evgestao.domain.Entities;
using bie.evgestao.domain.Enums;
using bie.evgestao.ui.mvc.Models;
using bie.evgestao.ui.viewmodels;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace bie.evgestao.ui.mvc.Controllers
{
    [Authorize(Roles = "Superadmin,Administrador")]
    public class UsuariosController : BaseController
    {
        private readonly IUsuarioAppService _UserAppSvc;

        private readonly UserManager<ApplicationUser> UserManager;
        private readonly RoleManager<IdentityRole> RoleManager;
        private readonly UserStore<ApplicationUser> UserStore;



        private readonly DbContext context;


        public UsuariosController(IUsuarioAppService svc1)
        {
            _UserAppSvc = svc1;
            context = new ApplicationDbContext();
            UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            RoleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            UserStore = new UserStore<ApplicationUser>(context);

        }



        #region API 
        // GET: GetJson 
        [Authorize(Roles = "Superadmin,Administrador")]
        public JsonResult GetJson()
        {
            Response.ClearHeaders();
            Response.ClearContent();
            Response.Clear();

            //carrega a lista de empresas.
            var roles = RoleManager.Roles.ToList();
            var usuarios = Mapper.Map<IEnumerable<Usuario>, IEnumerable<UsuarioViewmodel>>(_UserAppSvc.GetAll());


            var objSaida = from u in usuarios
                           join l in UserManager.Users.ToList() on u.id_usuario equals l.Id
                           select new UsuarioViewmodel
                           {
                               id_usuario = u.id_usuario,
                               Ativo = u.Ativo,
                               Nome = u.Nome,
                               Telefone = u.Telefone,
                               Telefone2 = u.Telefone2,
                               Funcao = u.Funcao,
                               Email = l.Email,
                               Roles = (
                                          from r in l.Roles
                                          join r2 in roles on r.RoleId equals r2.Id
                                          select r2.Name).ToList()
                           };

            // return new JsonResult2 { Data = objSaida, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            if (TipoUsuarioAtual == TipoUsuario.Superadmin)
            {
                return new JsonResult2 { Data = new { data = objSaida } };
            }
            else
            {
                return new JsonResult2 { Data = new { data = objSaida.Where(f => !f.Roles.Contains("Superadmin")) } };
            }


        }

        [Authorize(Roles = "Superadmin,Administrador")]
        public JsonResult Ativacao(string id)
        {
            var model = _UserAppSvc.GetById(id);
            if (model == null) throw new HttpException(404, "Item não encontrado");



            //verifica se o usuário é superadmin, se for vai retornar uma PUTA EXCEPTION
            if (UserManager.IsInRole(id, "Superadmin"))
            {
                throw new Exception("VOCÊ NÃO PODE DESATIVAR O USUARIO SUPERADMIN!");
            }



            //entidade 
            model.Ativo = !model.Ativo;
            _UserAppSvc.Update(model);

            ApplicationUser usuario = UserManager.FindById(id);
            UserManager.UpdateSecurityStamp(usuario.Id);





            return Json("OK");
        }

        [Authorize(Roles = "Superadmin,Administrador")]
        public JsonResult Deletar(string id)
        {
            var model = _UserAppSvc.GetById(id);
            if (model == null) throw new HttpException(404, "Item não encontrado");

            //Deleta o usuário do identity user 
            ApplicationUser usuario = UserManager.FindById(id);

            //verifica se o usuário é superadmin, se for vai retornar uma PUTA EXCEPTION
            if (UserManager.IsInRole(usuario.Id, "Superadmin"))
            {
                throw new Exception("VOCÊ NÃO PODE DELETAR O USUARIO SUPERADMIN!");
            }

            UserManager.UpdateSecurityStamp(usuario.Id);


            //deleta o usuario da aplicação
            _UserAppSvc.Remove(model);

            //deleta o usuario do profile 
            UserManager.Delete(usuario);

            return Json("OK");

        }


        #endregion




        // GET: Usuarios
        public ActionResult Index()
        {
            return View();
        }




        #region CRIAR 

        [HttpGet]
        [Authorize(Roles = "Superadmin,Administrador")]
        public ActionResult Criar()
        {


            #region Preparacao        


            //Gera as funções de acordo com as roles 
            List<string> TiposUsuarios = new List<string>();
            if (User.IsInRole("Superadmin"))
            {
                TiposUsuarios.Add("Superadmin");
                TiposUsuarios.Add("Administrador");

            }
            TiposUsuarios.Add("Secretaria");
            TiposUsuarios.Add("Financeiro");
            TiposUsuarios.Add("Pastor");
            TiposUsuarios.Add("Conselho");
            TiposUsuarios.Add("Lider");
            TiposUsuarios.Add("Supervisor");

            ViewBag.TiposUsuarios = new SelectList(TiposUsuarios);


            #endregion

            return View();

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Criar(UsuarioViewmodel model)
        {
            #region Preparacao        


            //Gera as funções de acordo com as roles 
            List<string> TiposUsuarios = new List<string>();
            if (User.IsInRole("Superadmin"))
            {
                TiposUsuarios.Add("Superadmin");
                TiposUsuarios.Add("Administrador");

            }

            TiposUsuarios.Add("Secretaria");
            TiposUsuarios.Add("Financeiro");
            TiposUsuarios.Add("Pastor");
            TiposUsuarios.Add("Conselho");
            TiposUsuarios.Add("Lider");
            TiposUsuarios.Add("Supervisor");

            ViewBag.TiposUsuarios = new SelectList(TiposUsuarios);

            #endregion



            if ((model.Tipo == TipoUsuario.Superadmin || model.Tipo == TipoUsuario.Administrador) && !User.IsInRole("Superadmin"))
            {
                ModelState.AddModelError(string.Empty,
                    "Erro de Acesso negado e validação do formulário");
                return View(model);
            }

            //verifica se o e-mail já existe.
            var existente = UserManager.FindByEmail(model.Email);
            if (existente != null)
            {
                ModelState.AddModelError("Email", "E-mail já cadastrado no sistema com outro usuário " + existente.Nome);
                return View(model);
            }


            var appUser = new ApplicationUser
            {
                UserName = model.Email,
                Email = model.Email,
                PhoneNumber = model.Telefone,
                EmailConfirmed = true,
                PhoneNumberConfirmed = true
            };

            var usrEntidade = new Usuario
            {
                Nome = model.Nome,
                Telefone = model.Telefone,
                Telefone2 = model.Telefone2,
                Email = model.Email,
                Ativo = true
            };

            try //Adiciona o usuário (Login)

            {
                UserManager.Create(appUser, model.Senha);
                UserManager.AddToRoles(appUser.Id, model.Funcao.ToString());
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty,
                    "Erro ao criar o usuário (identity). Favor informar o suporte técnico. O Erro foi: " + ex.Message);
                return View(model);
            }

            try //Adiciona o usuário (aplicação) 
            {
                usrEntidade.id_usuario = appUser.Id;
                _UserAppSvc.Add(usrEntidade);
                return RedirectToAction("index");
            }
            catch (Exception ex)
            {
                //deleta o usuário de identity recém criado
                UserManager.Delete(appUser);
                ModelState.AddModelError(string.Empty,
                   "Erro ao criar o usuário (aplicação). Favor informar o suporte técnico. O Erro foi: " + ex.Message);
                return View(model);

            }


        }

        #endregion



        #region EDITAR 

        [HttpGet]
        public async Task<ActionResult> Editar(string id)
        {

            //Carrega o usuário 
            var entidade = _UserAppSvc.GetById(id);
            if (entidade == null) throw new HttpException(404, "Usuário não encontrado");

            //carrega o viewmodel 
            var model = Mapper.Map<Usuario, UsuarioViewmodel>(entidade);

            //preenche as informações referentes ao login 
            var usuarioIdentity = await UserManager.FindByIdAsync(model.id_usuario);
            var roles = RoleManager.Roles.ToList();


            model.Email = usuarioIdentity.Email;
            model.Roles = (from r in usuarioIdentity.Roles
                           join r2 in roles on r.RoleId equals r2.Id
                           select r2.Name).ToList();


            //seta o tipo de acordo com a role
            model.Funcao = model.GetTipoFromRoles(model.Roles);


            #region Preparacao 

            //Gera as funções de acordo com as roles 


            //Gera as funções de acordo com as roles 
            List<string> TiposUsuarios = new List<string>();
            if (User.IsInRole("Superadmin"))
            {
                TiposUsuarios.Add("Superadmin");
                TiposUsuarios.Add("Administrador");

            }
            TiposUsuarios.Add("Secretaria");
            TiposUsuarios.Add("Financeiro");
            TiposUsuarios.Add("Pastor");
            TiposUsuarios.Add("Conselho");
            TiposUsuarios.Add("Lider");
            TiposUsuarios.Add("Supervisor");


            ViewBag.TiposUsuarios = new SelectList(TiposUsuarios, model.Tipo);


            #endregion

            return View(model);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Editar(UsuarioViewmodel model)
        {
            //Carrega o usuário 
            var entidade = _UserAppSvc.GetById(model.id_usuario);
            if (entidade == null) throw new HttpException(404, "Usuário não encontrado");

            var usuarioIdentity = await UserManager.FindByIdAsync(model.id_usuario);
            if (usuarioIdentity == null) throw new HttpException(404, "Usuário não encontrado");



            #region Preparacao 



            //Gera as funções de acordo com as roles 
            List<string> TiposUsuarios = new List<string>();
            if (User.IsInRole("Superadmin"))
            {
                TiposUsuarios.Add("Superadmin");
                TiposUsuarios.Add("Administrador");

            }
            TiposUsuarios.Add("Secretaria");
            TiposUsuarios.Add("Financeiro");
            TiposUsuarios.Add("Pastor");
            TiposUsuarios.Add("Conselho");
            TiposUsuarios.Add("Lider");
            TiposUsuarios.Add("Supervisor");

            ViewBag.TiposUsuarios = new SelectList(TiposUsuarios, model.Tipo);


            #endregion

            //verifica se o e-mail mudou.
            if (usuarioIdentity.Email.Trim() != model.Email.Trim()) //e-mail mudou! verificar no banco de usuários se há algum usuário já com esse e-mail
            {
                var existente = await UserManager.FindByEmailAsync(model.Email);
                if (existente != null)
                {
                    ModelState.AddModelError("Email", @"E-mail já cadastrado no sistema com outro usuário " + existente.Nome);
                    return View(model);
                }

                usuarioIdentity.Email = model.Email;
                usuarioIdentity.UserName = model.Email;


            }


            //verifica se a senha mudou 
            if (!string.IsNullOrEmpty(model.Senha))
            {
                String hashedNewPassword = UserManager.PasswordHasher.HashPassword(model.Senha);
                await UserStore.SetPasswordHashAsync(usuarioIdentity, hashedNewPassword);
            }
            //Atualiza o identity 
            await UserStore.UpdateAsync(usuarioIdentity);



            //carrega as roles do usuário 
            var roles = (from r in RoleManager.Roles.ToList()
                         join ur in usuarioIdentity.Roles on r.Id equals ur.RoleId
                         select r.Name).ToList();


            TipoUsuario tipoAtual = model.GetTipoFromRoles(roles);


            //mudou o tipo de usuário 
            if (tipoAtual != model.Funcao)
            {
                //TODO: Jogar uma validação de permissoes serverside aqui 


                if ((model.Funcao == TipoUsuario.Superadmin || model.Funcao == TipoUsuario.Administrador) && !User.IsInRole("Superadmin"))
                {
                    ModelState.AddModelError(string.Empty,
                        "Erro de Acesso negado e validação do formulário");
                    return View(model);
                }

                //remover a role anterior 
                await UserManager.RemoveFromRoleAsync(usuarioIdentity.Id, tipoAtual.ToString());

                //Adiciona a role nova 
                await UserManager.AddToRoleAsync(usuarioIdentity.Id, model.Funcao.ToString());
            }

            //atualiza a entidade 
            entidade.Nome = model.Nome;
            entidade.Telefone = model.Telefone;
            entidade.Telefone2 = model.Telefone2;
            entidade.Email = model.Email;
            _UserAppSvc.Update(entidade);
            return RedirectToAction("Index");

        }


        #endregion









    }
}