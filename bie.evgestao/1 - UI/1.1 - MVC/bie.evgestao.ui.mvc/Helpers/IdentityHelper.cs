﻿using System.Web;
using bie.evgestao.ui.mvc.Models;
using bie.evgestao.ui.viewmodels.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using bie.evgestao.domain.Enums;
using bie.evgestao.ui.viewmodels;

namespace bie.evgestao.ui.mvc.Helpers
{
    public static class IdentityHelper
    {
        public static ApplicationUser GetCurrentUser()
        {
            return
                HttpContext.Current.GetOwinContext()
                    .GetUserManager<ApplicationUserManager>()
                    .FindById(HttpContext.Current.User.Identity.GetUserId());
        }

        public static ItemMenuViewmodel[] GetMenuConfig()
        {
            var menus = new ItemMenuViewmodel[]
            {

                new ItemMenuViewmodel
                {
                    LinkText = "Home",
                    ActionName = "Index",
                    ControllerName = "Home",
                    Roles = "All",
                    Ordem = 0 ,
                }


            };

            return menus;
        }





    }
}