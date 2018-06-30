namespace bie.evgestao.infra.data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class remover_lixo_foto_pessoa : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.tb_pessoa", "FotoMime", c => c.String(maxLength: 60, unicode: false));
            DropColumn("dbo.tb_pessoa", "FotoExt");
        }
        
        public override void Down()
        {
            AddColumn("dbo.tb_pessoa", "FotoExt", c => c.String(maxLength: 30, unicode: false));
            AlterColumn("dbo.tb_pessoa", "FotoMime", c => c.String(maxLength: 300, unicode: false));
        }
    }
}
