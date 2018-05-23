using bie.evgestao.domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace bie.evgestao.infra.data.Configuration
{
    public class CargoConfiguration : EntityTypeConfiguration<Cargo>
    {
        public CargoConfiguration(string schema = "dbo")
        {
            ToTable(schema + ".tb_cargo");
            HasKey(p => p.id_cargo);

            Property(p => p.Nome).IsRequired().HasMaxLength(50);

            Property(p => p.Tipo).IsRequired();
        }
    }
}
