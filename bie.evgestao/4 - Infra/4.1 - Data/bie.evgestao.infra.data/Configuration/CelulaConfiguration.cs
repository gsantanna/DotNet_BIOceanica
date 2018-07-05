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

            Property(x => x.Nome).IsRequired().HasMaxLength(100);

            Property(x => x.Cep).IsOptional().HasMaxLength(20);

            Property(c => c.Endereco).IsOptional().HasMaxLength(250);

            Property(c => c.Bairro).IsOptional().HasMaxLength(50);

            Property(c => c.Numero).IsOptional().HasMaxLength(20);

            Property(x => x.Complemento).IsOptional().HasMaxLength(20);

            Property(c => c.Cidade).IsOptional().HasMaxLength(100);

            Property(c => c.UF).IsOptional();

            Property(c => c.Pais).IsOptional().HasMaxLength(30);



            Property(c => c.HoraReuniao).IsRequired().HasMaxLength(10);

            Property(c => c.DataCriacao).IsOptional();

            Property(c => c.Telefone1).IsOptional().HasMaxLength(15);

            Property(c => c.Telefone2).IsOptional().HasMaxLength(15);

            HasOptional(filho => filho.Coordenador).WithMany(pai => pai.CelulasCoordenadas).HasForeignKey(c => c.id_coordenador).WillCascadeOnDelete(true);
            HasOptional(filho => filho.Supervisor).WithMany(pai => pai.CelulasSupervisionadas).HasForeignKey(c => c.id_coordenador).WillCascadeOnDelete(true);




        }
    }
}
