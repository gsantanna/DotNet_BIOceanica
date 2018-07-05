namespace bie.evgestao.infra.data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ajustes_celula_diasemana : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tb_celula", "Ativo", c => c.Boolean(nullable: false));
            AlterColumn("dbo.tb_celula", "DiaReuniao", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.tb_celula", "DiaReuniao", c => c.String(nullable: false, maxLength: 30, unicode: false));
            DropColumn("dbo.tb_celula", "Ativo");
        }
    }
}
