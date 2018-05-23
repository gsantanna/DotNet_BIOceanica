using bie.evgestao.domain.Entities;
using System.Data.Entity.ModelConfiguration;
using static bie.evgestao.domain.Entities.Pessoa;

namespace bie.evgestao.infra.data.Configuration
{
    class TipoPessoaConfiguration : EntityTypeConfiguration<TipoPessoa>
    {
        public TipoPessoaConfiguration(string schema = "dbo")
        {
            ToTable(schema + ".tb_tipopessoa");
            HasKey(p => p.id_tipopessoa);

            Property(x => x.Nome).IsRequired().HasMaxLength(30);
        }
    }
}
