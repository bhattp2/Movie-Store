namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNewRental : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.MovieRentals", newName: "Rentals");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.Rentals", newName: "MovieRentals");
        }
    }
}
