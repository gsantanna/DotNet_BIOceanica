using bie.evgestao.domain.Entities;
using System.Data.Entity.ModelConfiguration;
using System;

namespace bie.evgestao.infra.data.Configuration
{
    class GrauParentescoConfiguration : EntityTypeConfiguration<GrauParentesco>
    {
        public GrauParentescoConfiguration(string schema = "dbo")
        {
            HasKey(x => x.id_grauparentesco);
            ToTable(schema + ".tb_grauparentesco");

            Property(x => x.Nome).IsRequired();
     }

    }
}
