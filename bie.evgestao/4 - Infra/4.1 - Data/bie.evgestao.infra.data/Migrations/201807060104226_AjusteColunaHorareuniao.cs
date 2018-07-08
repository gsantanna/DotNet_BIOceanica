namespace bie.evgestao.infra.data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AjusteColunaHorareuniao : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.tb_celula", "HoraReuniao", c => c.String(maxLength: 20, unicode: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.tb_celula", "HoraReuniao", c => c.String(nullable: false, maxLength: 10, unicode: false));
        }
    }
}
