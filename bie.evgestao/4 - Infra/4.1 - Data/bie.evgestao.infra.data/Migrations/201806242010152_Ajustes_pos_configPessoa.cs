namespace bie.evgestao.infra.data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Ajustes_pos_configPessoa : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.tb_pessoa", "id_cargo", "dbo.tb_cargo");
            DropForeignKey("dbo.tb_celula", "id_tipocelula", "dbo.tb_tipocelula");
            DropForeignKey("dbo.tb_familiar", "id_grauparentesco", "dbo.tb_grauparentesco");
            DropForeignKey("dbo.tb_pessoa", "id_situacaopessoa", "dbo.tb_situacaopessoa");
            DropForeignKey("dbo.tb_pessoa", "id_tipopessoa", "dbo.tb_tipopessoa");
            DropIndex("dbo.tb_pessoa", new[] { "id_situacaopessoa" });
            DropIndex("dbo.tb_pessoa", new[] { "id_tipopessoa" });
            DropIndex("dbo.tb_pessoa", new[] { "id_cargo" });
            DropIndex("dbo.tb_celula", new[] { "id_tipocelula" });
            DropIndex("dbo.tb_familiar", new[] { "id_grauparentesco" });
            AddColumn("dbo.tb_pessoa", "DataNascimento", c => c.DateTime());
            AddColumn("dbo.tb_pessoa", "TelefoneTrabalho", c => c.String(maxLength: 15, unicode: false));
            AddColumn("dbo.tb_pessoa", "TelefoneCelular", c => c.String(maxLength: 15, unicode: false));
            AddColumn("dbo.tb_pessoa", "Situacao", c => c.Int());
            AddColumn("dbo.tb_pessoa", "Entrada", c => c.Int());
            AddColumn("dbo.tb_pessoa", "Saida", c => c.Int());
            AddColumn("dbo.tb_pessoa", "Funcao", c => c.Int(nullable: false));
            AddColumn("dbo.tb_celula", "Telefone2", c => c.String(maxLength: 15, unicode: false));
            AddColumn("dbo.tb_celula", "TipoCelula", c => c.Int(nullable: false));
            AddColumn("dbo.tb_familiar", "Parentesco", c => c.Int(nullable: false));
            AlterColumn("dbo.tb_pessoa", "Nome", c => c.String(nullable: false, maxLength: 100, unicode: false));
            AlterColumn("dbo.tb_pessoa", "EstadoCivil", c => c.Int());
            AlterColumn("dbo.tb_pessoa", "Sexo", c => c.Int());
            AlterColumn("dbo.tb_pessoa", "ConhecidoComo", c => c.String(maxLength: 100, unicode: false));
            AlterColumn("dbo.tb_pessoa", "TipoSanguineo", c => c.Int(nullable: false));
            AlterColumn("dbo.tb_pessoa", "Endereco", c => c.String(maxLength: 250, unicode: false));
            AlterColumn("dbo.tb_pessoa", "Bairro", c => c.String(maxLength: 100, unicode: false));
            AlterColumn("dbo.tb_pessoa", "Numero", c => c.String(maxLength: 10, unicode: false));
            AlterColumn("dbo.tb_pessoa", "Complemento", c => c.String(maxLength: 50, unicode: false));
            AlterColumn("dbo.tb_pessoa", "Cidade", c => c.String(maxLength: 100, unicode: false));
            AlterColumn("dbo.tb_pessoa", "UF", c => c.String(maxLength: 2, unicode: false));
            AlterColumn("dbo.tb_pessoa", "Pais", c => c.String(maxLength: 100, unicode: false));
            AlterColumn("dbo.tb_pessoa", "Cep", c => c.String(maxLength: 15, unicode: false));
            AlterColumn("dbo.tb_pessoa", "Telefone", c => c.String(maxLength: 15, unicode: false));
            AlterColumn("dbo.tb_pessoa", "Email", c => c.String(maxLength: 100, unicode: false));
            AlterColumn("dbo.tb_pessoa", "Naturalidade", c => c.String(maxLength: 100, unicode: false));
            AlterColumn("dbo.tb_pessoa", "Nacionalidade", c => c.String(maxLength: 100, unicode: false));
            AlterColumn("dbo.tb_celula", "DataCriacao", c => c.DateTime());
            AlterColumn("dbo.tb_celula", "Telefone1", c => c.String(maxLength: 15, unicode: false));
            DropColumn("dbo.tb_pessoa", "id_situacaopessoa");
            DropColumn("dbo.tb_pessoa", "id_tipopessoa");
            DropColumn("dbo.tb_pessoa", "id_cargo");
            DropColumn("dbo.tb_pessoa", "Idade");
            DropColumn("dbo.tb_pessoa", "Status");
            DropColumn("dbo.tb_pessoa", "Profissao");
            DropColumn("dbo.tb_celula", "Telefine2");
            DropColumn("dbo.tb_celula", "id_tipocelula");
            DropColumn("dbo.tb_familiar", "id_grauparentesco");
            DropTable("dbo.tb_cargo");
            DropTable("dbo.tb_tipocelula");
            DropTable("dbo.tb_grauparentesco");
            DropTable("dbo.tb_situacaopessoa");
            DropTable("dbo.tb_tipopessoa");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.tb_tipopessoa",
                c => new
                    {
                        id_tipopessoa = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 30, unicode: false),
                        Tipo = c.String(maxLength: 300, unicode: false),
                    })
                .PrimaryKey(t => t.id_tipopessoa);
            
            CreateTable(
                "dbo.tb_situacaopessoa",
                c => new
                    {
                        id_situacaopessoa = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 30, unicode: false),
                        Tipo = c.String(maxLength: 300, unicode: false),
                    })
                .PrimaryKey(t => t.id_situacaopessoa);
            
            CreateTable(
                "dbo.tb_grauparentesco",
                c => new
                    {
                        id_grauparentesco = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 300, unicode: false),
                    })
                .PrimaryKey(t => t.id_grauparentesco);
            
            CreateTable(
                "dbo.tb_tipocelula",
                c => new
                    {
                        id_tipocelula = c.Int(nullable: false, identity: true),
                        Tipo = c.String(nullable: false, maxLength: 30, unicode: false),
                    })
                .PrimaryKey(t => t.id_tipocelula);
            
            CreateTable(
                "dbo.tb_cargo",
                c => new
                    {
                        id_cargo = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 50, unicode: false),
                        Tipo = c.String(nullable: false, maxLength: 300, unicode: false),
                    })
                .PrimaryKey(t => t.id_cargo);
            
            AddColumn("dbo.tb_familiar", "id_grauparentesco", c => c.Int(nullable: false));
            AddColumn("dbo.tb_celula", "id_tipocelula", c => c.Int(nullable: false));
            AddColumn("dbo.tb_celula", "Telefine2", c => c.String(nullable: false, maxLength: 10, unicode: false));
            AddColumn("dbo.tb_pessoa", "Profissao", c => c.String(nullable: false, maxLength: 50, unicode: false));
            AddColumn("dbo.tb_pessoa", "Status", c => c.Boolean(nullable: false));
            AddColumn("dbo.tb_pessoa", "Idade", c => c.Int(nullable: false));
            AddColumn("dbo.tb_pessoa", "id_cargo", c => c.Int(nullable: false));
            AddColumn("dbo.tb_pessoa", "id_tipopessoa", c => c.Int(nullable: false));
            AddColumn("dbo.tb_pessoa", "id_situacaopessoa", c => c.Int(nullable: false));
            AlterColumn("dbo.tb_celula", "Telefone1", c => c.String(nullable: false, maxLength: 10, unicode: false));
            AlterColumn("dbo.tb_celula", "DataCriacao", c => c.DateTime(nullable: false));
            AlterColumn("dbo.tb_pessoa", "Nacionalidade", c => c.String(nullable: false, maxLength: 50, unicode: false));
            AlterColumn("dbo.tb_pessoa", "Naturalidade", c => c.String(nullable: false, maxLength: 50, unicode: false));
            AlterColumn("dbo.tb_pessoa", "Email", c => c.String(nullable: false, maxLength: 100, unicode: false));
            AlterColumn("dbo.tb_pessoa", "Telefone", c => c.String(nullable: false, maxLength: 50, unicode: false));
            AlterColumn("dbo.tb_pessoa", "Cep", c => c.String(nullable: false, maxLength: 30, unicode: false));
            AlterColumn("dbo.tb_pessoa", "Pais", c => c.String(nullable: false, maxLength: 50, unicode: false));
            AlterColumn("dbo.tb_pessoa", "UF", c => c.String(nullable: false, maxLength: 50, unicode: false));
            AlterColumn("dbo.tb_pessoa", "Cidade", c => c.String(nullable: false, maxLength: 50, unicode: false));
            AlterColumn("dbo.tb_pessoa", "Complemento", c => c.String(maxLength: 300, unicode: false));
            AlterColumn("dbo.tb_pessoa", "Numero", c => c.String(nullable: false, maxLength: 10, unicode: false));
            AlterColumn("dbo.tb_pessoa", "Bairro", c => c.String(nullable: false, maxLength: 100, unicode: false));
            AlterColumn("dbo.tb_pessoa", "Endereco", c => c.String(nullable: false, maxLength: 300, unicode: false));
            AlterColumn("dbo.tb_pessoa", "TipoSanguineo", c => c.String(nullable: false, maxLength: 10, unicode: false));
            AlterColumn("dbo.tb_pessoa", "ConhecidoComo", c => c.String(nullable: false, maxLength: 50, unicode: false));
            AlterColumn("dbo.tb_pessoa", "Sexo", c => c.Int(nullable: false));
            AlterColumn("dbo.tb_pessoa", "EstadoCivil", c => c.String(nullable: false, maxLength: 50, unicode: false));
            AlterColumn("dbo.tb_pessoa", "Nome", c => c.String(nullable: false, maxLength: 150, unicode: false));
            DropColumn("dbo.tb_familiar", "Parentesco");
            DropColumn("dbo.tb_celula", "TipoCelula");
            DropColumn("dbo.tb_celula", "Telefone2");
            DropColumn("dbo.tb_pessoa", "Funcao");
            DropColumn("dbo.tb_pessoa", "Saida");
            DropColumn("dbo.tb_pessoa", "Entrada");
            DropColumn("dbo.tb_pessoa", "Situacao");
            DropColumn("dbo.tb_pessoa", "TelefoneCelular");
            DropColumn("dbo.tb_pessoa", "TelefoneTrabalho");
            DropColumn("dbo.tb_pessoa", "DataNascimento");
            CreateIndex("dbo.tb_familiar", "id_grauparentesco");
            CreateIndex("dbo.tb_celula", "id_tipocelula");
            CreateIndex("dbo.tb_pessoa", "id_cargo");
            CreateIndex("dbo.tb_pessoa", "id_tipopessoa");
            CreateIndex("dbo.tb_pessoa", "id_situacaopessoa");
            AddForeignKey("dbo.tb_pessoa", "id_tipopessoa", "dbo.tb_tipopessoa", "id_tipopessoa", cascadeDelete: true);
            AddForeignKey("dbo.tb_pessoa", "id_situacaopessoa", "dbo.tb_situacaopessoa", "id_situacaopessoa", cascadeDelete: true);
            AddForeignKey("dbo.tb_familiar", "id_grauparentesco", "dbo.tb_grauparentesco", "id_grauparentesco", cascadeDelete: true);
            AddForeignKey("dbo.tb_celula", "id_tipocelula", "dbo.tb_tipocelula", "id_tipocelula", cascadeDelete: true);
            AddForeignKey("dbo.tb_pessoa", "id_cargo", "dbo.tb_cargo", "id_cargo", cascadeDelete: true);
        }
    }
}
