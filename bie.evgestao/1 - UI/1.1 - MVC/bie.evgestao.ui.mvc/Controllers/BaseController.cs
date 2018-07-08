using System;
using System.Collections.Generic;
using System.Data.Entity;

using System.Web.Mvc;
using bie.evgestao.domain.Enums;
using bie.evgestao.ui.mvc.Models;
using bie.evgestao.ui.viewmodels;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using RestSharp;


namespace bie.evgestao.ui.mvc.Controllers
{
    [Authorize]
    public class BaseController : Controller
    {


        //Identity
        protected readonly UserManager<ApplicationUser> _userManager;
        protected readonly RoleManager<IdentityRole> _roleManager;
        protected readonly UserStore<ApplicationUser> _userStore;

        public BaseController()
        {

            DbContext context = new ApplicationDbContext();
            _userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));





        }

        public TipoUsuario TipoUsuarioAtual
        {
            get
            {
                if (User.IsInRole("Superadmin"))
                {
                    return TipoUsuario.Superadmin;

                }

                return TipoUsuario.Financeiro;
            }
        }

        public int IndicePermissao { get; set; }

        private const string ENDERECO_BASECEP = "https://viacep.com.br/ws/";
        public JsonResult cep(string id)
        {

            //garante que serão sempre 8 digitos
            id = id.PadLeft(8, '0').Substring(0, 8);

            var client = new RestClient(ENDERECO_BASECEP);
            var request = new RestRequest(id + "/json", Method.GET);
            var queryResult = client.Execute<CepViewmodel>(request).Data;


            return Json(queryResult, JsonRequestBehavior.AllowGet);
        }





    }
}