namespace bie.evgestao.infra.data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AjustesModeloDadosCelula : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tb_celula", "id_coordenador", c => c.Int());
            AddColumn("dbo.tb_celula", "id_supervisor", c => c.Int());
            AddColumn("dbo.tb_celula", "Cep", c => c.String(maxLength: 20, unicode: false));
            AlterColumn("dbo.tb_celula", "Endereco", c => c.String(maxLength: 250, unicode: false));
            AlterColumn("dbo.tb_celula", "Bairro", c => c.String(maxLength: 50, unicode: false));
            AlterColumn("dbo.tb_celula", "Complemento", c => c.String(maxLength: 20, unicode: false));
            AlterColumn("dbo.tb_celula", "Numero", c => c.String(maxLength: 20, unicode: false));
            AlterColumn("dbo.tb_celula", "Cidade", c => c.String(maxLength: 100, unicode: false));
            AlterColumn("dbo.tb_celula", "UF", c => c.Int());
            AlterColumn("dbo.tb_celula", "Pais", c => c.String(maxLength: 30, unicode: false));
            CreateIndex("dbo.tb_celula", "id_coordenador");
            AddForeignKey("dbo.tb_celula", "id_coordenador", "dbo.tb_pessoa", "id_pessoa", cascadeDelete: true);
            DropColumn("dbo.tb_celula", "Coordenador");
            DropColumn("dbo.tb_celula", "Supervidor");
        }
        
        public override void Down()
        {
            AddColumn("dbo.tb_celula", "Supervidor", c => c.String(nullable: false, maxLength: 100, unicode: false));
            AddColumn("dbo.tb_celula", "Coordenador", c => c.String(nullable: false, maxLength: 100, unicode: false));
            DropForeignKey("dbo.tb_celula", "id_coordenador", "dbo.tb_pessoa");
            DropIndex("dbo.tb_celula", new[] { "id_coordenador" });
            AlterColumn("dbo.tb_celula", "Pais", c => c.String(nullable: false, maxLength: 30, unicode: false));
            AlterColumn("dbo.tb_celula", "UF", c => c.String(nullable: false, maxLength: 10, unicode: false));
            AlterColumn("dbo.tb_celula", "Cidade", c => c.String(nullable: false, maxLength: 50, unicode: false));
            AlterColumn("dbo.tb_celula", "Numero", c => c.String(nullable: false, maxLength: 10, unicode: false));
            AlterColumn("dbo.tb_celula", "Complemento", c => c.String(maxLength: 300, unicode: false));
            AlterColumn("dbo.tb_celula", "Bairro", c => c.String(nullable: false, maxLength: 50, unicode: false));
            AlterColumn("dbo.tb_celula", "Endereco", c => c.String(nullable: false, maxLength: 250, unicode: false));
            DropColumn("dbo.tb_celula", "Cep");
            DropColumn("dbo.tb_celula", "id_supervisor");
            DropColumn("dbo.tb_celula", "id_coordenador");
        }
    }
}
