namespace CamionesApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AgregarActivo : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "activo", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "activo");
        }
    }
}
