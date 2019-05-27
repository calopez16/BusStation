namespace CamionesApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Atributos : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "tipodeUsuario", c => c.String());
            AddColumn("dbo.AspNetUsers", "nombreCamion", c => c.String());
            AddColumn("dbo.AspNetUsers", "latitud", c => c.String());
            AddColumn("dbo.AspNetUsers", "longitud", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "longitud");
            DropColumn("dbo.AspNetUsers", "latitud");
            DropColumn("dbo.AspNetUsers", "nombreCamion");
            DropColumn("dbo.AspNetUsers", "tipodeUsuario");
        }
    }
}
