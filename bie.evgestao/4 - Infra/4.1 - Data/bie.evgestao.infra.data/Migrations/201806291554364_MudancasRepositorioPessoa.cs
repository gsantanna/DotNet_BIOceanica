namespace bie.evgestao.infra.data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MudancasRepositorioPessoa : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.tb_pessoa", "UF", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.tb_pessoa", "UF", c => c.String(maxLength: 2, unicode: false));
        }
    }
}
