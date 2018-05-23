using bie.evgestao.domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace bie.evgestao.infra.data.Configuration
{
    class SituacaoPessoaConfiguration : EntityTypeConfiguration<SituacaoPessoa>
    {
        public SituacaoPessoaConfiguration(string schema = "dbo")
        {
            HasKey(x => x.id_situacaopessoa);
            ToTable(schema + ".tb_situacaopessoa");

            Property(x => x.Nome).IsRequired().HasMaxLength(30);

        }
    }
}
