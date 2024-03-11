namespace Calistenics.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UrlPropertyAddedToExerciseModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Excercises", "Url", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Excercises", "Url");
        }
    }
}
