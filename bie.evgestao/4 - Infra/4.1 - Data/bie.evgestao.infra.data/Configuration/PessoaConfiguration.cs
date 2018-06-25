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

            Property(p => p.Nome).IsRequired().HasMaxLength(100);
            Property(x => x.ConhecidoComo).IsOptional().HasMaxLength(100);
            Property(x => x.DataNascimento).IsOptional();


            Property(x => x.Endereco).IsOptional().HasMaxLength(250);

            Property(x => x.Numero).IsOptional().HasMaxLength(10);

            Property(x => x.Complemento).IsOptional().HasMaxLength(50);

            Property(x => x.Bairro).IsOptional().HasMaxLength(100);
            Property(x => x.Cidade).IsOptional().HasMaxLength(100);
            Property(x => x.UF).IsOptional().HasMaxLength(2);
            Property(x => x.Pais).IsOptional().HasMaxLength(100);
            Property(x => x.Cep).IsOptional().HasMaxLength(15);

            Property(x => x.Telefone).IsOptional().HasMaxLength(15);
            Property(x => x.TelefoneCelular).IsOptional().HasMaxLength(15);
            Property(x => x.TelefoneTrabalho).IsOptional().HasMaxLength(15);

            Property(x => x.Email).IsOptional().HasMaxLength(100);

            Property(x => x.Naturalidade).IsOptional().HasMaxLength(100);
            Property(x => x.Nacionalidade).IsOptional().HasMaxLength(100);





            //Ligação CELULA COM PESSOA
            //Padrão --> Filho para o Pai           
            HasOptional(filho => filho.Celula).WithMany(pai => pai.Pessoas).HasForeignKey(c => c.id_celula);





        }
    }
}
