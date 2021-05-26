namespace Entity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migracioninicial : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Flights", "ArrivalStation", c => c.String());
            DropColumn("dbo.Flights", "ArribalStation");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Flights", "ArribalStation", c => c.String());
            DropColumn("dbo.Flights", "ArrivalStation");
        }
    }
}
