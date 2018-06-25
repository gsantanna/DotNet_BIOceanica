using bie.evgestao.infra.data.Configuration;
using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;




namespace bie.evgestao.infra.data.Context
{

    public class MainDataContext : DbContext
    {
        public MainDataContext() : base("MainConnectionString")
        {
            //TODO : Veriry why we need this horrible hack to ensure Entities SQL dll is loaded.
            //source: http://robsneuron.blogspot.in/2013/11/entity-framework-upgrade-to-6.html
            var ensureDllIsCopied = System.Data.Entity.SqlServer.SqlProviderServices.Instance;

            Database.Log = Console.Write;
        }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Properties<string>()
                .Configure(p => p.HasColumnType("varchar"));

            modelBuilder.Properties<string>()
                .Configure(p => p.IsOptional());

            modelBuilder.Properties<string>()
                .Configure(p => p.HasMaxLength(300));

            modelBuilder.Properties<string>().Configure(p => p.IsUnicode(false));


            modelBuilder.Configurations.Add(new CelulaConfiguration());
            modelBuilder.Configurations.Add(new FamiliarConfiguration());
            modelBuilder.Configurations.Add(new FotoConfiguration());
            modelBuilder.Configurations.Add(new PessoaConfiguration());                        
            modelBuilder.Configurations.Add(new UsuarioConfiguration());




        }


    }




}
