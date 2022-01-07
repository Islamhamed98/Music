namespace GigsHub.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OverrideConventions : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Genres (Name) Values('Jazz')");
            Sql("INSERT INTO Genres (Name) Values('Rock')");
            Sql("INSERT INTO Genres (Name) Values('Blues')");
            Sql("INSERT INTO Genres (Name) Values('Country')");
        }
        
        public override void Down()
        {
            Sql("Delete from Genres Where Id IN (1,2,3,4)");
        }
    }
}
