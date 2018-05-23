using bie.evgestao.domain.Entities;
using System.Data.Entity.ModelConfiguration;


namespace bie.evgestao.infra.data.Configuration
{
    public class PessoaConfiguration : EntityTypeConfiguration<Pessoa>
    {
        public PessoaConfiguration(string schema = "dbo")
        {
            ToTable(schema + ".tb_pessoa");
            HasKey(p => p.id_pessoa);

            Property(p => p.Nome).IsRequired().HasMaxLength(150);

            Property(p => p.Idade).IsRequired();

            Property(p => p.Numero).IsRequired().HasMaxLength(10);

            Property(p => p.EstadoCivil).IsRequired().HasMaxLength(50);

            Property(p => p.Sexo).IsRequired();

            Property(p => p.TipoSanguineo).IsRequired().HasMaxLength(10);

            Property(p => p.ConhecidoComo).IsRequired().HasMaxLength(50);

            Property(p => p.endereco).IsRequired().HasMaxLength(300);

            Property(p => p.Bairro).IsRequired().HasMaxLength(100);

            Property(p => p.Telefone).IsRequired().HasMaxLength(50);

            Property(p => p.Cidade).IsRequired().HasMaxLength(50);

            Property(p => p.UF).IsRequired().HasMaxLength(50);

            Property(p => p.Cep).IsRequired().HasMaxLength(30);

            Property(p => p.Pais).IsRequired().HasMaxLength(50);

            Property(p => p.Email).IsRequired().HasMaxLength(100);

            Property(p => p.Profissao).IsRequired().HasMaxLength(50);

            Property(p => p.Naturalidade).IsRequired().HasMaxLength(50);

            Property(p => p.Nacionalidade).IsRequired().HasMaxLength(50);


            //Ligação CELULA COM PESSOA
            //Padrão --> Filho para o Pai           
            HasRequired(filho => filho.Celula).WithMany(pai => pai.Pessoas).HasForeignKey(c => c.id_celula);





        }
    }
}
