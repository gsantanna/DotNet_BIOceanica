using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using bie.evgestao.domain.Enums;
using bie.evgestao.ui.mvc.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;


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


    }
}