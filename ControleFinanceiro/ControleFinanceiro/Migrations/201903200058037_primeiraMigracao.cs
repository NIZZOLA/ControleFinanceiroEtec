namespace ControleFinanceiro.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class primeiraMigracao : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cliente",
                c => new
                    {
                        ClienteId = c.Int(nullable: false, identity: true),
                        CPF = c.String(maxLength: 18),
                        Nome = c.String(maxLength: 50),
                        Telefone = c.String(maxLength: 15),
                        Email = c.String(maxLength: 100),
                        Nascimento = c.DateTime(nullable: false),
                        Ativo = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ClienteId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Cliente");
        }
    }
}
