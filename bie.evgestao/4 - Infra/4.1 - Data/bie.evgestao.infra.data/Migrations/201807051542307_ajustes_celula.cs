namespace bie.evgestao.infra.data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ajustes_celula : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tb_celula", "Nome", c => c.String(nullable: false, maxLength: 100, unicode: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.tb_celula", "Nome");
        }
    }
}
