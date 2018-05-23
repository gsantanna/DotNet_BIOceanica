using bie.evgestao.domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace bie.evgestao.infra.data.Configuration
{
    class FamiliarConfiguration : EntityTypeConfiguration<Familiar>
    {
        public FamiliarConfiguration(string schema = "dbo")
        {
            ToTable(schema + ".tb_familiar");
            HasKey(x => x.id_familiar);

            Property(x => x.Nome).IsRequired().HasMaxLength(100);

            Property(x => x.id_familiar).IsRequired();

            Property(x => x.id_grauparentesco).IsRequired();
        }
    }
}
