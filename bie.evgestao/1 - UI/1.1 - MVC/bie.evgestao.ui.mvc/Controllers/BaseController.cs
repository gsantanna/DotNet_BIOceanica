using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
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
        private const string ENDERECO_BASECEP = "https://viacep.com.br/ws/";

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



        public JsonResult cep(int id)
        {


            var client = new RestClient(ENDERECO_BASECEP);
            var request = new RestRequest(id.ToString() + "/json", Method.GET);
            var queryResult = client.Execute<CepViewmodel>(request).Data;


            return Json(queryResult, JsonRequestBehavior.AllowGet);
        }

    }
}