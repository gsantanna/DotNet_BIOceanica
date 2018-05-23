using bie.evgestao.domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bie.evgestao.infra.data.Configuration
{

    internal class UsuarioConfiguration : EntityTypeConfiguration<Usuario>
    {
        public UsuarioConfiguration(string schema = "dbo")
        {
            ToTable(schema + ".tb_usuario");
            HasKey(c => c.id_usuario);

            Property(x => x.id_usuario).IsRequired();

 
            Property(x => x.Telefone).IsOptional();
            Property(x => x.Telefone2).IsOptional();

            Property(x => x.Email).HasMaxLength(200).IsOptional(); 

        }
    }
}
