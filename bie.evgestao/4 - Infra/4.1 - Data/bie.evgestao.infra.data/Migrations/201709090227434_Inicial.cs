namespace bie.evgestao.infra.data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Inicial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tb_cargo",
                c => new
                    {
                        id_cargo = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 50, unicode: false),
                        Tipo = c.String(nullable: false, maxLength: 300, unicode: false),
                    })
                .PrimaryKey(t => t.id_cargo);
            
            CreateTable(
                "dbo.tb_pessoa",
                c => new
                    {
                        id_pessoa = c.Int(nullable: false, identity: true),
                        id_celula = c.Int(nullable: false),
                        id_situacaopessoa = c.Int(nullable: false),
                        id_tipopessoa = c.Int(nullable: false),
                        id_cargo = c.Int(nullable: false),
                        Nome = c.String(nullable: false, maxLength: 150, unicode: false),
                        Idade = c.Int(nullable: false),
                        EstadoCivil = c.String(nullable: false, maxLength: 50, unicode: false),
                        Sexo = c.Int(nullable: false),
                        ConhecidoComo = c.String(nullable: false, maxLength: 50, unicode: false),
                        Status = c.Boolean(nullable: false),
                        TipoSanguineo = c.String(nullable: false, maxLength: 10, unicode: false),
                        endereco = c.String(nullable: false, maxLength: 300, unicode: false),
                        Bairro = c.String(nullable: false, maxLength: 100, unicode: false),
                        Numero = c.String(nullable: false, maxLength: 10, unicode: false),
                        Complemento = c.String(maxLength: 300, unicode: false),
                        Cidade = c.String(nullable: false, maxLength: 50, unicode: false),
                        UF = c.String(nullable: false, maxLength: 50, unicode: false),
                        Pais = c.String(nullable: false, maxLength: 50, unicode: false),
                        Cep = c.String(nullable: false, maxLength: 30, unicode: false),
                        Telefone = c.String(nullable: false, maxLength: 50, unicode: false),
                        Email = c.String(nullable: false, maxLength: 100, unicode: false),
                        Profissao = c.String(nullable: false, maxLength: 50, unicode: false),
                        Naturalidade = c.String(nullable: false, maxLength: 50, unicode: false),
                        Nacionalidade = c.String(nullable: false, maxLength: 50, unicode: false),
                    })
                .PrimaryKey(t => t.id_pessoa)
                .ForeignKey("dbo.tb_cargo", t => t.id_cargo, cascadeDelete: true)
                .ForeignKey("dbo.tb_celula", t => t.id_celula, cascadeDelete: true)
                .ForeignKey("dbo.tb_situacaopessoa", t => t.id_situacaopessoa, cascadeDelete: true)
                .ForeignKey("dbo.tb_tipopessoa", t => t.id_tipopessoa, cascadeDelete: true)
                .Index(t => t.id_celula)
                .Index(t => t.id_situacaopessoa)
                .Index(t => t.id_tipopessoa)
                .Index(t => t.id_cargo);
            
            CreateTable(
                "dbo.tb_celula",
                c => new
                    {
                        id_celula = c.Int(nullable: false, identity: true),
                        Coordenador = c.String(nullable: false, maxLength: 100, unicode: false),
                        Supervidor = c.String(nullable: false, maxLength: 100, unicode: false),
                        Endereco = c.String(nullable: false, maxLength: 250, unicode: false),
                        Bairro = c.String(nullable: false, maxLength: 50, unicode: false),
                        Complemento = c.String(maxLength: 300, unicode: false),
                        Numero = c.String(nullable: false, maxLength: 10, unicode: false),
                        Cidade = c.String(nullable: false, maxLength: 50, unicode: false),
                        UF = c.String(nullable: false, maxLength: 10, unicode: false),
                        Pais = c.String(nullable: false, maxLength: 30, unicode: false),
                        DiaReuniao = c.String(nullable: false, maxLength: 30, unicode: false),
                        HoraReuniao = c.String(nullable: false, maxLength: 10, unicode: false),
                        DataCriacao = c.DateTime(nullable: false),
                        Telefone1 = c.String(nullable: false, maxLength: 10, unicode: false),
                        Telefine2 = c.String(nullable: false, maxLength: 10, unicode: false),
                        id_tipocelula = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id_celula)
                .ForeignKey("dbo.tb_tipocelula", t => t.id_tipocelula, cascadeDelete: true)
                .Index(t => t.id_tipocelula);
            
            CreateTable(
                "dbo.tb_tipocelula",
                c => new
                    {
                        id_tipocelula = c.Int(nullable: false, identity: true),
                        Tipo = c.String(nullable: false, maxLength: 30, unicode: false),
                    })
                .PrimaryKey(t => t.id_tipocelula);
            
            CreateTable(
                "dbo.tb_familiar",
                c => new
                    {
                        id_familiar = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 100, unicode: false),
                        id_pessoa = c.Int(nullable: false),
                        id_grauparentesco = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id_familiar)
                .ForeignKey("dbo.tb_grauparentesco", t => t.id_grauparentesco, cascadeDelete: true)
                .ForeignKey("dbo.tb_pessoa", t => t.id_pessoa, cascadeDelete: true)
                .Index(t => t.id_pessoa)
                .Index(t => t.id_grauparentesco);
            
            CreateTable(
                "dbo.tb_grauparentesco",
                c => new
                    {
                        id_grauparentesco = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 300, unicode: false),
                    })
                .PrimaryKey(t => t.id_grauparentesco);
            
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
                "dbo.tb_tipopessoa",
                c => new
                    {
                        id_tipopessoa = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 30, unicode: false),
                        Tipo = c.String(maxLength: 300, unicode: false),
                    })
                .PrimaryKey(t => t.id_tipopessoa);
            
            CreateTable(
                "dbo.tb_foto",
                c => new
                    {
                        id_foto = c.Int(nullable: false, identity: true),
                        ArquivoFoto = c.Binary(nullable: false, maxLength: 100),
                        Mime = c.String(maxLength: 300, unicode: false),
                        Tamanho = c.Double(),
                    })
                .PrimaryKey(t => t.id_foto);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.tb_pessoa", "id_tipopessoa", "dbo.tb_tipopessoa");
            DropForeignKey("dbo.tb_pessoa", "id_situacaopessoa", "dbo.tb_situacaopessoa");
            DropForeignKey("dbo.tb_familiar", "id_pessoa", "dbo.tb_pessoa");
            DropForeignKey("dbo.tb_familiar", "id_grauparentesco", "dbo.tb_grauparentesco");
            DropForeignKey("dbo.tb_pessoa", "id_celula", "dbo.tb_celula");
            DropForeignKey("dbo.tb_celula", "id_tipocelula", "dbo.tb_tipocelula");
            DropForeignKey("dbo.tb_pessoa", "id_cargo", "dbo.tb_cargo");
            DropIndex("dbo.tb_familiar", new[] { "id_grauparentesco" });
            DropIndex("dbo.tb_familiar", new[] { "id_pessoa" });
            DropIndex("dbo.tb_celula", new[] { "id_tipocelula" });
            DropIndex("dbo.tb_pessoa", new[] { "id_cargo" });
            DropIndex("dbo.tb_pessoa", new[] { "id_tipopessoa" });
            DropIndex("dbo.tb_pessoa", new[] { "id_situacaopessoa" });
            DropIndex("dbo.tb_pessoa", new[] { "id_celula" });
            DropTable("dbo.tb_foto");
            DropTable("dbo.tb_tipopessoa");
            DropTable("dbo.tb_situacaopessoa");
            DropTable("dbo.tb_grauparentesco");
            DropTable("dbo.tb_familiar");
            DropTable("dbo.tb_tipocelula");
            DropTable("dbo.tb_celula");
            DropTable("dbo.tb_pessoa");
            DropTable("dbo.tb_cargo");
        }
    }
}
