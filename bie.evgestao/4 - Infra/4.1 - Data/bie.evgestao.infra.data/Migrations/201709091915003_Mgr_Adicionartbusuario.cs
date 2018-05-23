namespace bie.evgestao.infra.data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Mgr_Adicionartbusuario : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tb_usuario",
                c => new
                    {
                        id_usuario = c.String(nullable: false, maxLength: 300, unicode: false),
                        Nome = c.String(maxLength: 300, unicode: false),
                        Ativo = c.Boolean(nullable: false),
                        Telefone = c.String(maxLength: 300, unicode: false),
                        Telefone2 = c.String(maxLength: 300, unicode: false),
                        Email = c.String(maxLength: 200, unicode: false),
                    })
                .PrimaryKey(t => t.id_usuario);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.tb_usuario");
        }
    }
}
