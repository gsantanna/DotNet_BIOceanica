using bie.evgestao.domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace bie.evgestao.infra.data.Configuration
{
    class FotoConfiguration : EntityTypeConfiguration<Foto>
    {
        public FotoConfiguration(string schema = "dbo")
        {
            ToTable(schema + ".tb_foto");
            HasKey(x => x.id_foto);

            Property(x => x.id_foto).IsRequired();

            Property(x => x.ArquivoFoto).IsRequired().HasMaxLength(100);

            Property(x => x.Mime).IsOptional();

            Property(x => x.Tamanho).IsOptional();
        }
    }
}
