namespace bie.evgestao.infra.data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class historico : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tb_historicomovimentacaopessoa",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        id_pessoa = c.Int(nullable: false),
                        Data = c.DateTime(nullable: false),
                        Autor = c.String(nullable: false, maxLength: 100, unicode: false),
                        Movimento = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.tb_pessoa", t => t.id_pessoa, cascadeDelete: true)
                .Index(t => t.id_pessoa);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.tb_historicomovimentacaopessoa", "id_pessoa", "dbo.tb_pessoa");
            DropIndex("dbo.tb_historicomovimentacaopessoa", new[] { "id_pessoa" });
            DropTable("dbo.tb_historicomovimentacaopessoa");
        }
    }
}
