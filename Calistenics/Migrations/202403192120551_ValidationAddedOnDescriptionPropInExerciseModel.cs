namespace Calistenics.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ValidationAddedOnDescriptionPropInExerciseModel : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Excercises", "Description", c => c.String(maxLength: 200));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Excercises", "Description", c => c.String());
        }
    }
}
