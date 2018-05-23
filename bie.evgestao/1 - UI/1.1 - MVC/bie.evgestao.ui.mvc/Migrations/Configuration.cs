namespace bie.evgestao.ui.mvc.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<bie.evgestao.ui.mvc.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(bie.evgestao.ui.mvc.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            context.Roles.AddOrUpdate(r => r.Name,
                new IdentityRole { Name = "Secretaria" },
                new IdentityRole { Name = "Financeiro" },
                new IdentityRole { Name = "Pastor" },
                new IdentityRole { Name = "Conselho" },
                new IdentityRole { Name = "Lider" },
                new IdentityRole { Name = "Supervisor" },
                new IdentityRole { Name = "Administrador" },
                new IdentityRole { Name = "Superadmin" }
                );


            #region criarSuperadmin
            if (!(context.Users.Any(u => u.UserName == "superadmin@biexpert.com.br")))
            {
                using (UserStore<ApplicationUser> userStore = new UserStore<ApplicationUser>(context))
                {
                    using (UserManager<ApplicationUser> userManager = new UserManager<ApplicationUser>(userStore))
                    {
                        var userToInsert = new ApplicationUser
                        {
                            UserName = "superadmin@biexpert.com.br",
                            Email = "superadmin@biexpert.com.br",
                            PhoneNumber = "superadmin@biexpert.com.br",
                            Nome = "Super Admin",
                            EmailConfirmed = true,
                            PhoneNumberConfirmed = true
                        };

                        userManager.Create(userToInsert, "P@ssw0rd");

                        userManager.AddToRoles(userToInsert.Id, "Administrador");
                        userManager.AddToRoles(userToInsert.Id, "Superadmin");

                    }
                }
            }
            #endregion






        }
    }
}
