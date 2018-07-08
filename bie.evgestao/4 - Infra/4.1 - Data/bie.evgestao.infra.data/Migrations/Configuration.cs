namespace bie.evgestao.infra.data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;

    using bie.evgestao.domain.Entities;

    internal sealed class Configuration : DbMigrationsConfiguration<bie.evgestao.infra.data.Context.MainDataContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(bie.evgestao.infra.data.Context.MainDataContext context)
        {

            /*Comungante, Não-Comungante, Visitante, Fora de Sede.*/

                     





            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
