namespace bie.evgestao.infra.data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class pessoa_celula_001 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.tb_pessoa", "id_celula", "dbo.tb_celula");
            DropIndex("dbo.tb_pessoa", new[] { "id_celula" });
            AlterColumn("dbo.tb_pessoa", "id_celula", c => c.Int());
            CreateIndex("dbo.tb_pessoa", "id_celula");
            AddForeignKey("dbo.tb_pessoa", "id_celula", "dbo.tb_celula", "id_celula");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.tb_pessoa", "id_celula", "dbo.tb_celula");
            DropIndex("dbo.tb_pessoa", new[] { "id_celula" });
            AlterColumn("dbo.tb_pessoa", "id_celula", c => c.Int(nullable: false));
            CreateIndex("dbo.tb_pessoa", "id_celula");
            AddForeignKey("dbo.tb_pessoa", "id_celula", "dbo.tb_celula", "id_celula", cascadeDelete: true);
        }
    }
}
