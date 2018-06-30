namespace bie.evgestao.infra.data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FotoParapessoa : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tb_pessoa", "Foto", c => c.Binary());
            DropTable("dbo.tb_foto");
        }
        
        public override void Down()
        {
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
            
            DropColumn("dbo.tb_pessoa", "Foto");
        }
    }
}
