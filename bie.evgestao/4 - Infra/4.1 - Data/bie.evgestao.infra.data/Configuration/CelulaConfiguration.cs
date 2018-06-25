using bie.evgestao.domain.Entities;
using System.Data.Entity.ModelConfiguration;


namespace bie.evgestao.infra.data.Configuration
{
    class CelulaConfiguration : EntityTypeConfiguration<Celula>
    {
        public CelulaConfiguration(string schema = "dbo")
        {
            HasKey(x => x.id_celula);
            ToTable(schema + ".tb_celula");

            Property(c => c.Coordenador).IsRequired().HasMaxLength(100);

            Property(c => c.Supervidor).IsRequired().HasMaxLength(100);

            Property(c => c.Endereco).IsRequired().HasMaxLength(250);

            Property(c => c.Bairro).IsRequired().HasMaxLength(50);

            Property(c => c.Numero).IsRequired().HasMaxLength(10);

            Property(c => c.Cidade).IsRequired().HasMaxLength(50);

            Property(c => c.UF).IsRequired().HasMaxLength(10);

            Property(c => c.Pais).IsRequired().HasMaxLength(30);

            Property(c => c.DiaReuniao).IsRequired().HasMaxLength(30);

            Property(c => c.HoraReuniao).IsRequired().HasMaxLength(10);

            Property(c => c.DataCriacao).IsOptional();

            Property(c => c.Telefone1).IsOptional().HasMaxLength(15);

            Property(c => c.Telefone2).IsOptional().HasMaxLength(15);





        }
    }
}
