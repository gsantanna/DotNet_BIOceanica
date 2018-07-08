namespace bie.evgestao.infra.data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FotoParapessoa2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tb_pessoa", "FotoExt", c => c.String(maxLength: 30, unicode: false));
            AddColumn("dbo.tb_pessoa", "FotoMime", c => c.String(maxLength: 300, unicode: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.tb_pessoa", "FotoMime");
            DropColumn("dbo.tb_pessoa", "FotoExt");
        }
    }
}
