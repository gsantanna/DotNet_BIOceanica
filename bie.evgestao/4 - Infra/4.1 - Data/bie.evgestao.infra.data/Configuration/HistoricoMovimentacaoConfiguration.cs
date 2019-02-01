using bie.evgestao.domain.Entities;
using System.Data.Entity.ModelConfiguration;


namespace bie.evgestao.infra.data.Configuration
{
    public class HistoricoMovimentacaoConfiguration : EntityTypeConfiguration<HistoricoMovimentacao>
    {
        public HistoricoMovimentacaoConfiguration(string schema = "dbo")
        {
            ToTable(schema + ".tb_historicomovimentacaopessoa");
            HasKey(x => x.id);

            Property(x => x.id).HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);

            Property(x => x.Autor).IsRequired().HasMaxLength(100);

            Property(x => x.Movimento).HasColumnType("varchar(max)");

            
            //histórico para pessoa
            HasRequired(filho => filho.Pessoa).WithMany(pai => pai.Historico).HasForeignKey(c => c.id_pessoa);





        }
    }
}
