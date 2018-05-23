using bie.evgestao.domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace bie.evgestao.infra.data.Configuration
{
    class TipoCelulaConfiguration : EntityTypeConfiguration<TipoCelula>
    {
        public TipoCelulaConfiguration(string schema = "dbo")
        {
            ToTable(schema + ".tb_tipocelula");
            HasKey(p => p.id_tipocelula);

            Property(x => x.Tipo).IsRequired().HasMaxLength(30);



           


        }
    }
}
