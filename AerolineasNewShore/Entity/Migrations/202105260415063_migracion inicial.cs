namespace Entity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migracioninicial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Flights",
                c => new
                    {
                        IdFlight = c.Int(nullable: false, identity: true),
                        DepartureStation = c.String(),
                        ArribalStation = c.String(),
                        DepartureDate = c.DateTime(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Currency = c.String(),
                        Transport_FlightNumber = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.IdFlight)
                .ForeignKey("dbo.Transports", t => t.Transport_FlightNumber)
                .Index(t => t.Transport_FlightNumber);
            
            CreateTable(
                "dbo.Transports",
                c => new
                    {
                        FlightNumber = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.FlightNumber);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Flights", "Transport_FlightNumber", "dbo.Transports");
            DropIndex("dbo.Flights", new[] { "Transport_FlightNumber" });
            DropTable("dbo.Transports");
            DropTable("dbo.Flights");
        }
    }
}
